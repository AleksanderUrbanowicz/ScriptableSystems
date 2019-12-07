
using Characters;
using UnityEditor;
using UnityEngine;
 
namespace EditorTools
{
    [CustomPropertyDrawer(typeof(EmployeeData),false)]
    public class EmployeeDataPropertyDrawer : PropertyDrawer
    {
        private float _height = 100;
        private float _indent = 30;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return _height;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive),
                                  new GUIContent(label.text));

            var idProperty = property.FindPropertyRelative("id");
            var displayNameProperty = property.FindPropertyRelative("displayName");
            var characterTypeProperty = property.FindPropertyRelative("characterType");
           // EditorGUILayout.PropertyField(idProperty,new  GUIContent("Id: "));

            EditorGUI.EndProperty();
        }
    }

}


