using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using ScriptableSystems;
using EditorTools;

namespace Characters
{
    [CustomEditor(typeof(CharactersConfig))]
    public class CharactersConfigEditor : Editor
    {
        private SerializedProperty colorsSetProperty;
        private SerializedProperty characterTypesProperty;
        private SerializedProperty guestTypesProperty;
        private SerializedProperty employeeTypesProperty;
        private SerializedProperty labelledBoolsProperty;

        

        private SerializedProperty labelledBoolProperty;
        public Color[] defaultColors = new Color[Enum.GetValues(typeof(ColorPurpose)).Length];

        private readonly float smallControlHeight = 16;
        private readonly float mediumControlHeight = 20;
        private readonly float largeControlHeight = 24;
        private readonly float hugeControlHeight = 28;
        private readonly float spaceFloat = 5.0f;


        private static readonly string[] doNotDrawProperties = new string[]
        {
            "option1",
            "colorsSet",
            "characterTypes",
            "employeeTypes",
            "guestTypes",
            "LabelledBool",
              "LabelledBools"
        };

        public bool DefinitionsTabOpen;
        public bool GeneratorTabOpen;

        public bool ColorsCustomizerTabOpen;


        private void OnEnable()
        {

            serializedObject.Update();          
            labelledBoolProperty  = serializedObject.FindProperty("labelledBool");
            employeeTypesProperty= serializedObject.FindProperty("employeeTypes");
            guestTypesProperty = serializedObject.FindProperty("guestTypes");
            labelledBoolsProperty = serializedObject.FindProperty("labelledBools");

            
            characterTypesProperty = serializedObject.FindProperty("characterTypes");

            colorsSetProperty = serializedObject.FindProperty("colorsSet");

            for (int i = 0; i < Enum.GetValues(typeof(ColorPurpose)).Length; i++)

            {
                Color color = colorsSetProperty.GetArrayElementAtIndex(i).colorValue;
                defaultColors[i] = color;
            }
        }

        public override void OnInspectorGUI()
        {
            GUI.color = EditorColorsCustomizer.GetColor(ColorPurpose.MainColor, ref defaultColors);

            GUI.backgroundColor = EditorColorsCustomizer.GetColor(ColorPurpose.BackgroundColorLight, ref defaultColors);

            GUIStyle myStyle = GUI.skin.GetStyle("HelpBox");
            myStyle.richText = true;


            string tabText;

            //////////////////////DefinitionsTab/////////////////////////////////
            if (DefinitionsTabOpen)
            {
                GUI.color = EditorColorsCustomizer.GetColor(ColorPurpose.WarningColor, ref defaultColors);

                tabText = "Close";
            }
            else
            {
                GUI.color = EditorColorsCustomizer.GetColor(ColorPurpose.ConfirmColor, ref defaultColors);

                tabText = "Open";
            }

            EditorGUILayout.BeginHorizontal();

            DefinitionsTabOpen = GUILayout.Toggle(DefinitionsTabOpen,
                tabText + " Definitions", "button", GUILayout.ExpandWidth(true),
                GUILayout.Height(hugeControlHeight));
            GUI.color = EditorColorsCustomizer.GetColor(ColorPurpose.MainColor, ref defaultColors);

            if (GUILayout.Button("?", GUILayout.Height(hugeControlHeight), GUILayout.Width(hugeControlHeight)))
            {
                var activatorRect = GUILayoutUtility.GetLastRect();
                EditorGUILayout.HelpBox(
                    "Help text",
                    MessageType.Info, true);
                

            }
            EditorGUILayout.EndHorizontal();
             EditorGUILayout.BeginVertical();
            //GUILayout.BeginHorizontal();
            if (DefinitionsTabOpen)
            {
                
                EditorGUILayout.PropertyField(characterTypesProperty, true);
                EditorGUILayout.PropertyField(employeeTypesProperty, true);
                EditorGUILayout.PropertyField(guestTypesProperty, true);
                

            }
            EditorGUILayout.EndVertical();
           // GUILayout.EndHorizontal();
            ///////////////////////////////////GeneratorTab/////////////////////////////////////////////////////////////


            if (GeneratorTabOpen)
            {
                GUI.color = EditorColorsCustomizer.GetColor(ColorPurpose.WarningColor, ref defaultColors);

                tabText = "Close";
            }
            else
            {
                GUI.color = EditorColorsCustomizer.GetColor(ColorPurpose.ConfirmColor, ref defaultColors);

                tabText = "Open";
            }

            EditorGUILayout.BeginHorizontal();

            GeneratorTabOpen = GUILayout.Toggle(GeneratorTabOpen,
                tabText + " Generator", "button", GUILayout.ExpandWidth(true),
                GUILayout.Height(hugeControlHeight));
            GUI.color = EditorColorsCustomizer.GetColor(ColorPurpose.MainColor, ref defaultColors);

            if (GUILayout.Button("?", GUILayout.Height(hugeControlHeight), GUILayout.Width(hugeControlHeight)))
            {
                var activatorRect = GUILayoutUtility.GetLastRect();
                EditorGUILayout.HelpBox(
                    "Help text",
                    MessageType.Info, true);
            }

            EditorGUILayout.EndHorizontal();
            if (GeneratorTabOpen)
            {
                EditorGUILayout.BeginVertical();
                { 

                    if (GUILayout.Button("New Character", GUILayout.Height(hugeControlHeight), GUILayout.ExpandWidth(true)))
                    {
                        var activatorRect = GUILayoutUtility.GetLastRect();
                        EditorGUILayout.HelpBox(
                            "New Charactert",
                            MessageType.Info, true);
                    }

                  


                }
                EditorGUILayout.EndVertical();

            }

            ////////////////ColorsCustomizerTab/////////////////////////////////////////////////////////////////

            GUI.color = EditorColorsCustomizer.GetColor(ColorPurpose.MainColor, ref defaultColors);


            if (ColorsCustomizerTabOpen)
            {
                GUI.color = EditorColorsCustomizer.GetColor(ColorPurpose.WarningColor, ref defaultColors);

                tabText = "Close";
            }
            else
            {
                GUI.color = EditorColorsCustomizer.GetColor(ColorPurpose.ConfirmColor, ref defaultColors);

                tabText = "Open";
            }

            EditorGUILayout.BeginVertical();

            //GUI.color = EditorColorsCustomizer.GetColor(ColorPurpose.MainColor, ref defaultColors);


            ColorsCustomizerTabOpen = GUILayout.Toggle(ColorsCustomizerTabOpen, tabText + " Colors customizer tab",
                "button", GUILayout.ExpandWidth(true), GUILayout.Height(hugeControlHeight));


            if (ColorsCustomizerTabOpen)
            {
                for (int i = 0; i < colorsSetProperty.arraySize; i++)
                {
                    EditorGUILayout.BeginHorizontal();

                    GUI.backgroundColor = colorsSetProperty.GetArrayElementAtIndex(i).colorValue;
                    EditorGUILayout.LabelField(((ColorPurpose)i) + " :", GUILayout.Height(smallControlHeight));
                    colorsSetProperty.GetArrayElementAtIndex(i).colorValue =
                        EditorGUILayout.ColorField(colorsSetProperty.GetArrayElementAtIndex(i).colorValue);

                    defaultColors[i] = colorsSetProperty.GetArrayElementAtIndex(i).colorValue;
                    EditorGUILayout.EndHorizontal();
                }



                GUI.backgroundColor =
                    EditorColorsCustomizer.GetColor(ColorPurpose.BackgroundColorLight, ref defaultColors);


                GUI.color = EditorColorsCustomizer.GetColor(ColorPurpose.MainColor, ref defaultColors);

                EditorGUILayout.LabelField("Main");
                GUI.color = EditorColorsCustomizer.GetColor(ColorPurpose.ConfirmColor, ref defaultColors);
                EditorGUILayout.LabelField("Confirm");

                GUI.color = EditorColorsCustomizer.GetColor(ColorPurpose.WarningColor, ref defaultColors);
                EditorGUILayout.LabelField("Warning");

                GUI.color = EditorColorsCustomizer.GetColor(ColorPurpose.NegateColor, ref defaultColors);
                EditorGUILayout.LabelField("Negate");

                GUI.color = EditorColorsCustomizer.GetColor(ColorPurpose.MainColor, ref defaultColors);
            }

            EditorGUILayout.EndVertical();
            GUI.backgroundColor = EditorColorsCustomizer.GetColor(ColorPurpose.BackgroundColorLight, ref defaultColors);

            GUI.color = EditorColorsCustomizer.GetColor(ColorPurpose.MainColor, ref defaultColors);

            DrawPropertiesExcluding(serializedObject, doNotDrawProperties);

            serializedObject.ApplyModifiedProperties();
        }

    }
        
    
}