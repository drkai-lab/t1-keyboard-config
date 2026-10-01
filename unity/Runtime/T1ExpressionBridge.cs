using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

namespace T1Expression
{
    /// <summary>
    /// T1 keyboard expression bridge: receives OSC messages and drives avatar expressions.
    /// Works with VRChat (VRCExpressionParameters) and generic Animator parameters.
    /// </summary>
    [DefaultExecutionOrder(-100)]
    public class T1ExpressionBridge : MonoBehaviour
    {
        [Header("OSC Settings")]
        [Tooltip("UDP port to listen on (must match the sender's port)")]
        public int listenPort = 9000;

        [Header("Avatar")]
        [Tooltip("The avatar's Animator (optional, for generic expression control)")]
        public Animator avatarAnimator;

        [Tooltip("VRChat expression parameters (optional, for VRChat avatars)")]
        public VRCExpressionParameters vrcParameters;

        [Header("Expression Mappings")]
        [Tooltip("List of T1 key -> expression mappings")]
        public List<ExpressionMapping> mappings = new List<ExpressionMapping>();

        [Header("Debug")]
        public bool showDebugLog = true;

        private UdpClient _udpClient;
        private Thread _receiveThread;
        private bool _isRunning;
        private readonly object _lock = new object();

        // Track the current state of each expression
        private readonly Dictionary<string, bool> _expressionStates = new Dictionary<string, bool>();

        [Serializable]
        public class ExpressionMapping
        {
            [Tooltip("T1 key name (e.g. KEY1, KEY2, ..., K1-L, K1-R)")]
            public string t1Key = "KEY1";

            [Tooltip("OSC address to listen for (e.g. /avatar/parameters/Expression1)")]
            public string oscAddress = "/avatar/parameters/Expression1";

            [Tooltip("Animator parameter name (for generic avatars)")]
            public string animatorParameter = "Expression1";

            [Tooltip("Expression type")]
            public ExpressionType type = ExpressionType.Bool;

            [Tooltip("For Int expressions: the value to set when active")]
            public int intValue = 1;

            [Tooltip("For Float expressions: the value to set when active")]
            public float floatValue = 1f;
        }

        public enum ExpressionType
        {
            Bool,
            Int,
            Float
        }

        private void OnEnable()
        {
            StartReceiver();
        }

        private void OnDisable()
        {
            StopReceiver();
        }

        private void StartReceiver()
        {
            if (_isRunning) return;

            try
            {
                _udpClient = new UdpClient(listenPort);
                _udpClient.Client.ReceiveTimeout = 1000;
                _isRunning = true;
                _receiveThread = new Thread(ReceiveLoop)
                {
                    IsBackground = true,
                    Name = "T1ExpressionOSC"
                };
                _receiveThread.Start();

                if (showDebugLog)
                    Debug.Log($"[T1Expression] Listening for OSC on port {listenPort}");
            }
            catch (Exception e)
            {
                Debug.LogError($"[T1Expression] Failed to start OSC receiver: {e.Message}");
            }
        }

        private void StopReceiver()
        {
            _isRunning = false;
            _udpClient?.Close();
            _udpClient?.Dispose();
            _udpClient = null;
            _receiveThread = null;
        }

        private void ReceiveLoop()
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, listenPort);

            while (_isRunning)
            {
                try
                {
                    byte[] data = _udpClient.Receive(ref endPoint);
                    string message = Encoding.UTF8.GetString(data);
                    ProcessOscMessage(message);
                }
                catch (SocketException) { /* timeout, continue */ }
                catch (ObjectDisposedException) { break; }
                catch (Exception e)
                {
                    if (_isRunning && showDebugLog)
                        Debug.LogWarning($"[T1Expression] Receive error: {e.Message}");
                }
            }
        }

        private void ProcessOscMessage(byte[] data)
        {
            // Parse OSC message: address + type tag + value
            // Format: /address\0\0\0,type\0\0value
            try
            {
                int i = 0;

                // Read address (null-terminated, padded to 4 bytes)
                int addrEnd = Array.IndexOf(data, (byte)0, i);
                if (addrEnd < 0) return;
                string address = Encoding.UTF8.GetString(data, i, addrEnd - i);
                i = (addrEnd + 1 + 3) & ~3; // align to 4 bytes

                // Read type tag (comma-prefixed, null-terminated, padded)
                if (i >= data.Length || data[i] != (byte)',') return;
                int tagEnd = Array.IndexOf(data, (byte)0, i);
                if (tagEnd < 0) return;
                string typeTag = Encoding.UTF8.GetString(data, i, tagEnd - i);
                i = (tagEnd + 1 + 3) & ~3;

                // Parse value based on type tag
                bool boolValue = false;
                int intValue = 0;
                float floatValue = 0f;

                if (typeTag.StartsWith("T"))
                {
                    boolValue = true;
                }
                else if (typeTag.StartsWith("F"))
                {
                    boolValue = false;
                }
                else if (typeTag.StartsWith("i") && i + 4 <= data.Length)
                {
                    intValue = BitConverter.ToInt32(data, i);
                    i += 4;
                }
                else if (typeTag.StartsWith("f") && i + 4 <= data.Length)
                {
                    floatValue = BitConverter.ToSingle(data, i);
                    i += 4;
                }

                // Find matching mapping and apply
                lock (_lock)
                {
                    foreach (var mapping in mappings)
                    {
                        if (mapping.oscAddress == address)
                        {
                            ApplyExpression(mapping, boolValue, intValue, floatValue);
                            break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                if (showDebugLog)
                    Debug.LogWarning($"[T1Expression] Parse error: {e.Message}");
            }
        }

        private void ApplyExpression(ExpressionMapping mapping, bool boolValue, int intValue, floatValue)
        {
            if (showDebugLog)
                Debug.Log($"[T1Expression] {mapping.t1Key} -> {mapping.oscAddress} = {boolValue}");

            // VRChat expression parameters
            if (vrcParameters != null)
            {
                var param = FindVrcParameter(mapping.animatorParameter);
                if (param != null)
                {
                    switch (mapping.type)
                    {
                        case ExpressionType.Bool:
                            param.value = boolValue ? 1f : 0f;
                            break;
                        case ExpressionType.Int:
                            param.value = boolValue ? mapping.intValue : 0;
                            break;
                        case ExpressionType.Float:
                            param.value = boolValue ? mapping.floatValue : 0f;
                            break;
                    }
                }
            }

            // Generic Animator parameters
            if (avatarAnimator != null)
            {
                switch (mapping.type)
                {
                    case ExpressionType.Bool:
                        avatarAnimator.SetBool(mapping.animatorParameter, boolValue);
                        break;
                    case ExpressionType.Int:
                        avatarAnimator.SetInteger(mapping.animatorParameter, boolValue ? mapping.intValue : 0);
                        break;
                    case ExpressionType.Float:
                        avatarAnimator.SetFloat(mapping.animatorParameter, boolValue ? mapping.floatValue : 0f);
                        break;
                }
            }

            _expressionStates[mapping.oscAddress] = boolValue;
        }

        private VRCExpressionParameters.Parameter FindVrcParameter(string name)
        {
            if (vrcParameters == null) return null;
            foreach (var param in vrcParameters.parameters)
            {
                if (param.name == name)
                    return param;
            }
            return null;
        }

        /// <summary>
        /// Get the current state of an expression.
        /// </summary>
        public bool GetExpressionState(string oscAddress)
        {
            lock (_lock)
            {
                return _expressionStates.TryGetValue(oscAddress, out bool state) && state;
            }
        }

        /// <summary>
        /// Manually trigger an expression (for testing).
        /// </summary>
        public void TriggerExpression(string oscAddress, bool active)
        {
            lock (_lock)
            {
                foreach (var mapping in mappings)
                {
                    if (mapping.oscAddress == oscAddress)
                    {
                        ApplyExpression(mapping, active, 0, 0);
                        break;
                    }
                }
            }
        }

        private void OnApplicationQuit()
        {
            StopReceiver();
        }
    }
}
