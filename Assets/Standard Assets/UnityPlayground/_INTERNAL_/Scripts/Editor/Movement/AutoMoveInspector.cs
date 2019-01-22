using UnityEngine;
using System.Collections;
using UnityEditor;

namespace UnityPlayground
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(AutoMove))]
    public class AutoMoveInspector : InspectorBase
    {
        private string explanation = "The GameObject moves automatically in a specific direction.";

        public override void OnInspectorGUI()
        {
            GUILayout.Space(10);
            EditorGUILayout.HelpBox(explanation, MessageType.Info);

            base.OnInspectorGUI();
        }
    }
}