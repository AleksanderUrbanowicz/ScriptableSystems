using Characters;
using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace EditorTools
{
    public class EmployeeTypeSelector : CharactersSelectorPropertyAttribute
    {
        protected override void UpdateParameters()
        {

#if UNITY_EDITOR
            if (charactersConfig == null)
            {
                charactersConfig = EditorStaticTools.GetFirstInstance<CharactersConfig>();
            }

#endif

            if (charactersConfig != null)
            {

                parameters = charactersConfig.employeeTypes.Select(x => x.id).ToArray();

            }

        }
    }


#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(EmployeeTypeSelector))]
    public class EmployeeTypeSelectorDrawer : PropertyDrawer
    {

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var stringInList = attribute as EmployeeTypeSelector;
            var list = stringInList.Elements;
            if (property.propertyType == SerializedPropertyType.String)
            {
                int index = Mathf.Max(0, Array.IndexOf(list, property.stringValue));
                index = EditorGUI.Popup(position, property.displayName, index, list);

                if (list == null || list.Length == 0)
                {

                    property.stringValue = "NULL";
                }
                else
                {
                    property.stringValue = list[index];
                }
            }

            else
            {
                base.OnGUI(position, property, label);
            }
        }
    }
#endif
}