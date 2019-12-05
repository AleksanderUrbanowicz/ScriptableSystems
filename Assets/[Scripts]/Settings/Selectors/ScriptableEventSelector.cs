using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;
using System;

namespace EditorTools
{
    public class ScriptableEventSelector : SelectorPropertyAttribute
    {
        protected override void UpdateParameters()
        {
            bool b = definitionsConfig == null;
#if UNITY_EDITOR
            if (b)
            {
                definitionsConfig = EditorStaticTools.GetFirstInstance<Definitions>();
                b = definitionsConfig == null;
            }

#endif

            if (!b)
            {

                parameters = definitionsConfig.scriptableEvents.Select(x => x.id).ToArray();

            }
            
        }
    }


#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(ScriptableEventSelector))]
    public class ScriptableEventSelectorDrawer : PropertyDrawer
    {

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var stringInList = attribute as ScriptableEventSelector;
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