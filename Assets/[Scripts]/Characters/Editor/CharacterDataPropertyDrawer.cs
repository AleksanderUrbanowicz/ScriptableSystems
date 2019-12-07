
using Characters;
using UnityEditor;
using UnityEngine;
 
namespace EditorTools
{ 
//[CustomPropertyDrawer(typeof(CharacterDataBase),false)]
public class CharacterDataPropertyDrawer : PropertyDrawer
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
            var  displayNameProperty = property.FindPropertyRelative("displayName");
            var characterTypeProperty = property.FindPropertyRelative("characterType");

           
            EditorGUI.EndProperty();
    }
}

}
