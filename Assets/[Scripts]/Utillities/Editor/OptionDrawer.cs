using UnityEditor;
using UnityEngine;


namespace EditorTools
{
    [CustomPropertyDrawer(typeof(OptionProperty))]
    public class OptionDrawer : PropertyDrawer
    {
        private const float width = 1.0f;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return 20;
        }


        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            position = EditorGUI.IndentedRect(position);
            position.width -= 5;

            var indentLevel = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            SerializedProperty optionProperty = property.FindPropertyRelative("option");

            SerializedProperty defaultOptionProperty = property.FindPropertyRelative("defaultOption");


     


            EditorGUI.LabelField(
                new Rect(position.x + 5, position.y, (position.width / 3) * 2 - 5,
                    position.height), property.name);

       if (optionProperty.boolValue == true)
            {
                GUI.color = Color.green;
            }
            else
            {
                GUI.color = Color.white;
            }

            EditorGUI.PropertyField(
                new Rect(position.x + (position.width / 3) * 2 + 5, position.y,
                    (position.width / 8) - 5, position.height),
                optionProperty, GUIContent.none);

            GUI.color = Color.white;

            EditorGUI.LabelField(
                new Rect(position.x + (position.width / 4) * 3 + 5, position.y,
                    (position.width / 3) - 5,
                    position.height), "Default: ");

            EditorGUI.BeginDisabledGroup(true);

            if (defaultOptionProperty.boolValue == true)
            {
                GUI.color = Color.green;
            }
            else
            {
                GUI.color = Color.white;
            }
            
            EditorGUI.PropertyField(
                new Rect(position.x + (position.width / 10) * 9 + 5, position.y,
                    (position.width / 8) - 5, position.height),
                defaultOptionProperty, GUIContent.none);
            EditorGUI.indentLevel = indentLevel;

            EditorGUI.EndDisabledGroup();

            EditorGUI.indentLevel = indentLevel;
            GUI.color = Color.white;
            EditorGUI.EndProperty();
        }
    }
}