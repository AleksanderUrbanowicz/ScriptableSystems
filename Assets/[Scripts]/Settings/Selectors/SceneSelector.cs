using System;
using UnityEditor;
using UnityEngine;

namespace EditorTools
{
    public class SceneSelector : DefinitionsSelectorPropertyAttribute
    {
        protected override void UpdateParameters()
        {

#if UNITY_EDITOR
            parameters = EditorStaticTools.GetAllScenes();

#endif


        }

#if UNITY_EDITOR
        [CustomPropertyDrawer(typeof(SceneSelector))]
        public class SceneSelectorDrawer : PropertyDrawer
        {

            public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
            {
                var stringInList = attribute as SceneSelector;
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

}