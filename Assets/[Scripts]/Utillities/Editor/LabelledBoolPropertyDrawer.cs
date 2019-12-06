using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


namespace EditorTools
{
    [CustomPropertyDrawer(typeof(LabelledBool))]
    public class LabelledBoolPropertyDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return 20;
        }


        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            position = EditorGUI.IndentedRect(position);
            position.width -= 20;

            var indentLevel = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;
           

            SerializedProperty valueProperty = property.FindPropertyRelative("val");


            EditorGUI.PropertyField(
                new Rect(position.x, position.y, (position.width / 3) * 2 - 5, position.height),
                property.FindPropertyRelative("id"), GUIContent.none);

            if (valueProperty != null)
            {
                if (valueProperty.boolValue == true)
                {
                    GUI.color = Color.green;
                }
                else
                {
                    GUI.color = Color.red;
                }
            }

            EditorGUI.PropertyField(
                new Rect(position.x + (position.width / 6) * 5 + 5, position.y,
                    (position.width / 8) - 5, position.height),
                valueProperty, GUIContent.none);


            GUI.color = Color.white;

            EditorGUI.indentLevel = indentLevel;

            EditorGUI.EndProperty();
        }
    }
}