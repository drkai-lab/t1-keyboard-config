using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace T1Expression.EditorTools
{
    /// <summary>
    /// One-click setup for the T1 Expression Bridge.
    /// Creates a GameObject with the bridge component and opens the settings window.
    /// </summary>
    public static class T1ExpressionSetup
    {
        [MenuItem("Tools/T1 Expression/Setup Bridge")]
        public static void SetupBridge()
        {
            // Create the bridge GameObject
            var bridgeObj = new GameObject("T1 Expression Bridge");
            var bridge = bridgeObj.AddComponent<T1ExpressionBridge>();

            // Try to find the avatar's animator in the scene
            var animator = Object.FindObjectOfType<Animator>();
            if (animator != null)
            {
                bridge.avatarAnimator = animator;
                Debug.Log($"[T1Expression] Auto-assigned Animator from: {animator.gameObject.name}");
            }

            // Select the new object and open settings
            Selection.activeGameObject = bridgeObj;
            EditorGUIUtility.PingObject(bridgeObj);
            T1ExpressionSettingsWindow.ShowWindow();

            Debug.Log("[T1Expression] Bridge created! Configure mappings in the settings window.");
        }

        [MenuItem("Tools/T1 Expression/Create Sample Mappings")]
        public static void CreateSampleMappings()
        {
            var bridge = Object.FindObjectOfType<T1ExpressionBridge>();
            if (bridge == null)
            {
                EditorUtility.DisplayDialog("Error",
                    "No T1ExpressionBridge found. Run 'Setup Bridge' first.", "OK");
                return;
            }

            bridge.mappings.Clear();
            for (int i = 0; i < 10; i++)
            {
                bridge.mappings.Add(new T1ExpressionBridge.ExpressionMapping
                {
                    t1Key = $"KEY{i + 1}",
                    oscAddress = $"/avatar/parameters/Expression{i + 1}",
                    animatorParameter = $"Expression{i + 1}",
                    type = T1ExpressionBridge.ExpressionType.Bool
                });
            }

            EditorUtility.SetDirty(bridge);
            Debug.Log("[T1Expression] Created 10 sample mappings (KEY1-10 -> Expression1-10)");
        }
    }
}
