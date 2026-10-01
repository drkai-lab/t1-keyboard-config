using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace T1Expression.EditorTools
{
    /// <summary>
    /// Editor window for configuring T1 keyboard expression mappings.
    /// Beginner-friendly: no code required, just fill in the form.
    /// </summary>
    public class T1ExpressionSettingsWindow : EditorWindow
    {
        private T1ExpressionBridge _bridge;
        private Vector2 _scrollPos;
        private bool _showHelp = true;

        // Preset expression names for VRChat
        private static readonly string[] VrcExpressionPresets = new[]
        {
            "Expression1", "Expression2", "Expression3", "Expression4",
            "Expression5", "Expression6", "Expression7", "Expression8",
            "Expression9", "Expression10", "Expression11", "Expression12",
            "Expression13", "Expression14", "Expression15", "Expression16",
            "FaceHappy", "FaceSad", "FaceAngry", "FaceSurprised",
            "FaceBlink", "FaceSmile", "FaceFrown", "FaceOpenMouth",
            "HandThumbsUp", "HandPoint", "HandFist", "HandOpen",
            "GimmickOn", "GimmickOff", "Toggle1", "Toggle2"
        };

        // T1 key names
        private static readonly string[] T1KeyNames = new[]
        {
            "KEY1", "KEY2", "KEY3", "KEY4", "KEY5", "KEY6",
            "KEY7", "KEY8", "KEY9", "KEY10", "KEY11", "KEY12",
            "K1-L", "K1-R", "K2-L", "K2-R"
        };

        [MenuItem("Tools/T1 Expression Settings")]
        public static void ShowWindow()
        {
            var window = GetWindow<T1ExpressionSettingsWindow>("T1 Expression Settings");
            window.minSize = new Vector2(500, 400);
            window.Show();
        }

        private void OnGUI()
        {
            _bridge = FindObjectOfType<T1ExpressionBridge>();

            if (_bridge == null)
            {
                DrawNoBridgeWarning();
                return;
            }

            DrawHeader();
            DrawBridgeSettings();
            DrawMappings();
            DrawFooter();
        }

        private void DrawNoBridgeWarning()
        {
            GUILayout.Space(20);
            GUILayout.Label("No T1ExpressionBridge found in the scene!", EditorStyles.boldLabel);
            GUILayout.Space(10);
            GUILayout.Label("To use the T1 Expression Bridge:");
            GUILayout.Label("1. Select your avatar in the Hierarchy");
            GUILayout.Label("2. Click 'Add T1 Expression Bridge' below");
            GUILayout.Label("3. Configure the mappings in the Inspector");
            GUILayout.Space(20);

            if (GUILayout.Button("Add T1 Expression Bridge to Selected Object", GUILayout.Height(40)))
            {
                var selected = Selection.activeGameObject;
                if (selected != null)
                {
                    _bridge = selected.AddComponent<T1ExpressionBridge>();
                    Selection.activeGameObject = _bridge.gameObject;
                    GUIUtility.ExitGUI();
                }
                else
                {
                    EditorUtility.DisplayDialog("Error",
                        "Please select your avatar GameObject in the Hierarchy first.", "OK");
                }
            }
        }

        private void DrawHeader()
        {
            _showHelp = GUILayout.Toggle(_showHelp, "Help", EditorStyles.foldout);
            if (_showHelp)
            {
                EditorGUILayout.HelpBox(
                    "T1 Expression Bridge\n\n" +
                    "This tool connects your T1 keyboard to avatar expressions via OSC.\n\n" +
                    "Setup:\n" +
                    "1. Set the OSC port (must match your sender, default 9000)\n" +
                    "2. Assign your avatar's Animator (optional)\n" +
                    "3. Add mappings: T1 key -> OSC address -> expression\n" +
                    "4. Run your T1 keyboard tool and press keys to trigger expressions\n\n" +
                    "For VRChat: assign VRCExpressionParameters\n" +
                    "For generic avatars: use Animator parameters",
                    MessageType.Info);
                GUILayout.Space(10);
            }
        }

        private void DrawBridgeSettings()
        {
            GUILayout.Label("Bridge Settings", EditorStyles.boldLabel);
            _bridge.listenPort = EditorGUILayout.IntField("OSC Port", _bridge.listenPort);
            _bridge.avatarAnimator = (Animator)EditorGUILayout.ObjectField(
                "Avatar Animator", _bridge.avatarAnimator, typeof(Animator), true);
            _bridge.vrcParameters = (VRCExpressionParameters)EditorableObjectField(
                "VRC Expression Parameters", _bridge.vrcParameters, typeof(VRCExpressionParameters), true);
            _bridge.showDebugLog = Toggl("Show Debug Log", _bridge.showDebugLog);
            GUILayout.Space(10);
        }

        private void DrawMappings()
        {
            GUILayout.Label("Expression Mappings", EditorStyles.boldLabel);
            GUILayout.Label("Map T1 keys to OSC addresses and expression parameters", EditorStyles.miniLabel);
            GUILayout.Space(5);

            _scrollPos = GUILayout.BeginScrollView(_scrollPos, GUILayout.MinHeight(200));

            for (int i = 0; i < _bridge.mappings.Count; i++)
            {
                DrawMapping(i);
            }

            GUILayout.EndScrollView();

            if (GUILayout.Button("+ Add Mapping", GUILayout.Height(30)))
            {
                _bridge.mappings.Add(new T1ExpressionBridge.ExpressionMapping
                {
                    t1Key = "KEY1",
                    oscAddress = "/avatar/parameters/Expression1",
                    animatorParameter = "Expression1",
                    type = T1ExpressionBridge.ExpressionType.Bool
                });
                EditorUtility.SetDirty(_bridge);
            }

            if (_bridge.mappings.Count > 0 &&
                GUILayout.Button("- Remove Last Mapping", GUILayout.Height(25)))
            {
                _bridge.mappings.RemoveAt(_bridge.mappings.Count - 1);
                EditorUtility.SetDirty(_bridge);
            }

            GUILayout.Space(10);
        }

        private void DrawMapping(int index)
        {
            var mapping = _bridge.mappings[index];

            GUILayout.BeginVertical("box");
            GUILayout.Label($"Mapping {index + 1}", EditorStyles.boldLabel);

            // T1 Key dropdown
            int keyIndex = Array.IndexOf(T1KeyNames, mapping.t1Key);
            if (keyIndex < 0) keyIndex = 0;
            keyIndex = EditorGUILayout.Popup("T1 Key", keyIndex, T1KeyNames);
            mapping.t1Key = T1KeyNames[keyIndex];

            // OSC Address
            mapping.oscAddress = EditorGUILayout.TextField("OSC Address", mapping.oscAddress);

            // Expression type
            mapping.type = (T1ExpressionBridge.ExpressionType)EditorGUILayout.EnumPopup(
                "Type", mapping.type);

            // Animator parameter with preset dropdown
            int presetIndex = Array.IndexOf(VrcExpressionPresets, mapping.animatorParameter);
            string paramInput = mapping.animatorParameter;
            paramInput = EditorGUILayout.TextField("Animator Parameter", paramInput);
            mapping.animatorParameter = paramInput;

            // Preset buttons
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Presets", GUILayout.Width(60)))
            {
                ShowPresetMenu(mapping);
            }
            if (GUILayout.Button("Clear", GUILayout.Width(50)))
            {
                mapping.animatorParameter = "";
            }
            GUILayout.EndHorizontal();

            // Type-specific fields
            if (mapping.type == T1ExpressionBridge.ExpressionType.Int)
            {
                mapping.intValue = Mathf.RoundToInt(EditorGUILayout.FloatField(
                    "Active Value", mapping.intValue));
            }
            else if (mapping.type == T1ExpressionBridge.ExpressionType.Float)
            {
                mapping.floatValue = EditorGUILayout.FloatField("Active Value", mapping.floatValue);
            }

            // Test button
            if (GUILayout.Button("Test Trigger", GUILayout.Height(25)))
            {
                mapping.t1Key, true);
                EditorApplication.QueuePlayerLoopUpdate();
            }

            GUILayout.EndVertical();
            GUILayout.Space(5);
        }

        private void ShowPresetMenu(T1ExpressionBridge.ExpressionMapping mapping)
        {
            var menu = new GenericMenu();
            foreach (var preset in VrcExpressionPresets)
            {
                string captured = preset;
                menu.AddItem(new GUIContent(preset), false, () =>
                {
                    mapping.animatorParameter = captured;
                    EditorUtility.SetDirty(_bridge);
                });
            }
            menu.ShowAsContext();
        }

        private void DrawFooter()
        {
            GUILayout.Space(10);
            GUILayout.Label("Quick Actions", EditorStyles.boldLabel);

            if (GUILayout.Button("Auto-Fill Default Mappings", GUILayout.Height(30)))
            {
                if (EditorUtility.DisplayDialog("Auto-Fill Mappings",
                    "This will replace all current mappings with defaults (KEY1-10 -> Expression1-10). Continue?",
                    "Yes", "Cancel"))
                {
                    _bridge.mappings.Clear();
                    for (int i = 0; i < 10; i++)
                    {
                        _bridge.mappings.Add(new T1ExpressionBridge.ExpressionMapping
                        {
                            t1Key = $"KEY{i + 1}",
                            oscAddress = $"/avatar/parameters/Expression{i + 1}",
                            animatorParameter = $"Expression{i + 1}",
                            type = T1ExpressionBridge.ExpressionType.Bool
                        });
                    }
                    EditorUtility.SetDirty(_bridge);
                }
            }

            if (GUILayout.Button("Clear All Mappings", GUILayout.Height(25)))
            {
                if (EditorUtility.DisplayDialog("Clear Mappings",
                    "Remove all mappings?", "Yes", "Cancel"))
                {
                    _bridge.mappings.Clear();
                    EditorUtility.SetDirty(_bridge);
                }
            }
        }
    }
}
