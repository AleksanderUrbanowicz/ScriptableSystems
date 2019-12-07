using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using ScriptableSystems;
using EditorTools;
using System.Linq;
using Characters;

namespace EditorTools
{
    [CustomEditor(typeof(MainConfigNew))]
    public class MainConfigEditorNew : Editor
    {
        private SerializedProperty colorsSetProperty;
        private SerializedProperty characterTypesProperty;
        private SerializedProperty guestTypesProperty;
        private SerializedProperty employeeTypesProperty;
        private SerializedProperty labelledBoolsProperty;
        private SerializedProperty characterDatasProperty;
        private SerializedProperty employeeDatasProperty;
        private SerializedProperty guestDatasProperty;
        private SerializedProperty labelledBoolProperty;
        private SerializedProperty selectedCharacterDataProperty;
        private SerializedProperty employeeColorProperty;
        private SerializedProperty guestColorProperty;

        private SerializedProperty DefinitionsTabOpenProperty;
        private SerializedProperty GeneratorTabOpenProperty;
        private SerializedProperty ColorsCustomizerTabOpenProperty;
        public static CharacterDataBase CharacterDataBase { get { return characterDataBase; } }
        GameObject sceneObject;
        bool displayObject = false;
        private static CharacterDataBase characterDataBase;

        public Color[] defaultColors = new Color[Enum.GetValues(typeof(ColorPurpose)).Length];

        // public List<CharacterDataBase> characterDatas;
        //public List<EmployeeData> employeeDatas;
        // public List<GuestData> guestDatas;

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
              "LabelledBools",
              "guestDatas",
              "employeeDatas",
              "employeeColor",
              "guestColor",
              "characterDatas",
              "generatorTabOpen",
              "definitionsTabOpen",
              "colorsCustomizerTabOpen"
        };



        private void OnEnable()
        {

            serializedObject.Update();
            labelledBoolProperty = serializedObject.FindProperty("labelledBool");
            employeeTypesProperty = serializedObject.FindProperty("employeeTypes");
            guestTypesProperty = serializedObject.FindProperty("guestTypes");
            labelledBoolsProperty = serializedObject.FindProperty("labelledBools");


            characterDatasProperty = serializedObject.FindProperty("characterDatas");
            employeeDatasProperty = serializedObject.FindProperty("employeeDatas");
            guestDatasProperty = serializedObject.FindProperty("guestDatas");
            employeeColorProperty = serializedObject.FindProperty("employeeColor");
            guestColorProperty = serializedObject.FindProperty("guestColor");
            GeneratorTabOpenProperty = serializedObject.FindProperty("generatorTabOpen");
            ColorsCustomizerTabOpenProperty = serializedObject.FindProperty("colorsCustomizerTabOpen");
            DefinitionsTabOpenProperty = serializedObject.FindProperty("definitionsTabOpen");
            characterTypesProperty = serializedObject.FindProperty("characterTypes");

            colorsSetProperty = serializedObject.FindProperty("colorsSet");

            for (int i = 0; i < Enum.GetValues(typeof(ColorPurpose)).Length; i++)

            {
                if (colorsSetProperty.arraySize > i)
                {
                    Color color = colorsSetProperty.GetArrayElementAtIndex(i).colorValue;
                    defaultColors[i] = color;
                }
            }
        }

        public override void OnInspectorGUI()
        {
            GUI.color = EditorColorsCustomizer.GetColor(ColorPurpose.MainColor, ref defaultColors);
            DrawPropertiesExcluding(serializedObject, doNotDrawProperties);
            GUI.backgroundColor = EditorColorsCustomizer.GetColor(ColorPurpose.BackgroundColorLight, ref defaultColors);

            GUIStyle myStyle = GUI.skin.GetStyle("HelpBox");
            myStyle.richText = true;


            string tabText;

            //////////////////////DefinitionsTab/////////////////////////////////
            if (DefinitionsTabOpenProperty.boolValue)
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

            DefinitionsTabOpenProperty.boolValue = GUILayout.Toggle(DefinitionsTabOpenProperty.boolValue,
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
            if (DefinitionsTabOpenProperty.boolValue)
            {

                EditorGUILayout.PropertyField(characterTypesProperty, true);
                EditorGUILayout.PropertyField(employeeTypesProperty, true);
                EditorGUILayout.PropertyField(guestTypesProperty, true);


            }
            EditorGUILayout.EndVertical();
            ///////////////////////////////////GeneratorTab/////////////////////////////////////////////////////////////


            if (GeneratorTabOpenProperty.boolValue)
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

            GeneratorTabOpenProperty.boolValue = GUILayout.Toggle(GeneratorTabOpenProperty.boolValue,
                tabText + " Generator", "button", GUILayout.ExpandWidth(true),
                GUILayout.Height(hugeControlHeight));
            GUI.color = EditorColorsCustomizer.GetColor(ColorPurpose.MainColor, ref defaultColors);

            if (GUILayout.Button("?", GUILayout.Height(hugeControlHeight), GUILayout.Width(hugeControlHeight)))
            {

            }

            EditorGUILayout.EndHorizontal();
            if (GeneratorTabOpenProperty.boolValue)
            {
                EditorGUILayout.BeginVertical();
                {
                    DrawCharacterCreator();


                }
                EditorGUILayout.EndVertical();

            }

            ////////////////ColorsCustomizerTab/////////////////////////////////////////////////////////////////

            GUI.color = EditorColorsCustomizer.GetColor(ColorPurpose.MainColor, ref defaultColors);


            if (ColorsCustomizerTabOpenProperty.boolValue)
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


            ColorsCustomizerTabOpenProperty.boolValue = GUILayout.Toggle(ColorsCustomizerTabOpenProperty.boolValue, tabText + " Colors customizer tab",
                "button", GUILayout.ExpandWidth(true), GUILayout.Height(hugeControlHeight));


            if (ColorsCustomizerTabOpenProperty.boolValue)
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


                EditorGUILayout.BeginHorizontal();

                GUI.backgroundColor = guestColorProperty.colorValue;
                EditorGUILayout.LabelField(" Guest:", GUILayout.Height(smallControlHeight));
                guestColorProperty.colorValue =
                    EditorGUILayout.ColorField(guestColorProperty.colorValue);

                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();

                GUI.backgroundColor = employeeColorProperty.colorValue;
                EditorGUILayout.LabelField(" Employee:", GUILayout.Height(smallControlHeight));
                employeeColorProperty.colorValue =
                    EditorGUILayout.ColorField(employeeColorProperty.colorValue);

                EditorGUILayout.EndHorizontal();
                GUI.backgroundColor =
                    EditorColorsCustomizer.GetColor(ColorPurpose.BackgroundColorLight, ref defaultColors);


            }

            EditorGUILayout.EndVertical();
            GUI.backgroundColor = EditorColorsCustomizer.GetColor(ColorPurpose.BackgroundColorLight, ref defaultColors);

            GUI.color = EditorColorsCustomizer.GetColor(ColorPurpose.MainColor, ref defaultColors);

            serializedObject.ApplyModifiedProperties();
        }

        private void InitCharacterData()
        {
            characterDataBase = (CharacterDataBase)ScriptableObject.CreateInstance(typeof(CharacterDataBase));
        }

        public void DrawCharactersList()
        {


            EditorGUILayout.BeginHorizontal();


            EditorGUILayout.BeginVertical(GUI.skin.GetStyle("HelpBox"), GUILayout.Width(Screen.width / 4));
            DrawEmployeesList();
            DrawGuestsList();


            EditorGUILayout.EndVertical();
            DrawCharacterDisplay(characterDataBase);
            //DrawCharacterDisplay(selectedCharacterDataProperty);
            EditorGUILayout.EndHorizontal();
        }


        public void DrawEmployeesList()
        {
            GUI.backgroundColor = employeeColorProperty.colorValue;

            EditorGUILayout.BeginVertical(GUI.skin.GetStyle("HelpBox"));

            for (int i = 0; i < employeeDatasProperty.arraySize; i++)
            {
                // EditorGUILayout.BeginHorizontal();
                EmployeeData employeeData = employeeDatasProperty.GetArrayElementAtIndex(i).objectReferenceValue as EmployeeData;

                if (GUILayout.Button(employeeData.displayName, GUILayout.Height(hugeControlHeight), GUILayout.Width(Screen.width / 4.0f)))
                {
                    //var activatorRect = GUILayoutUtility.GetLastRect();
                    //DrawCharacterDisplay(employeeData);
                    //selectedCharacterDataProperty = employeeDatasProperty.GetArrayElementAtIndex(i);
                    characterDataBase = employeeData;
                }

                //EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.EndVertical();
            GUI.backgroundColor = EditorColorsCustomizer.GetColor(ColorPurpose.BackgroundColorLight, ref defaultColors);

        }

        public void DrawGuestsList()
        {
            GUI.backgroundColor = guestColorProperty.colorValue;
            EditorGUILayout.BeginVertical(GUI.skin.GetStyle("HelpBox"));

            for (int i = 0; i < guestDatasProperty.arraySize; i++)
            {
                //EditorGUILayout.BeginHorizontal();
                GuestData guestData = guestDatasProperty.GetArrayElementAtIndex(i).objectReferenceValue as GuestData;

                if (GUILayout.Button(guestData.displayName, GUILayout.Height(hugeControlHeight), GUILayout.Width(Screen.width / 4.0f)))
                {
                    //var activatorRect = GUILayoutUtility.GetLastRect();
                    characterDataBase = guestData;
                    // selectedCharacterDataProperty = guestDatasProperty.GetArrayElementAtIndex(i);
                    // DrawCharacterDisplay(guestData);
                }

                //EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.EndVertical();
            GUI.backgroundColor = EditorColorsCustomizer.GetColor(ColorPurpose.BackgroundColorLight, ref defaultColors);

        }


        public void DrawCharacterDisplay(CharacterDataBase characterData)
        {

            if (characterData == null)
            {

                return;
            }
            EditorGUILayout.BeginVertical(GUI.skin.GetStyle("HelpBox"), GUILayout.ExpandWidth(true));

            characterData.id = EditorGUILayout.TextField(new GUIContent("Id: "), characterData.id, GUILayout.Height(smallControlHeight));

            characterData.displayName = EditorGUILayout.TextField(new GUIContent("Name: "), characterData.displayName, GUILayout.Height(smallControlHeight));

            if (characterData is EmployeeData)
            {
                //Display additional
                (characterData as EmployeeData).salary = EditorGUILayout.FloatField(new GUIContent("Wage: "), (characterData as EmployeeData).salary, GUILayout.Height(smallControlHeight));

                (characterData as EmployeeData).skill = EditorGUILayout.FloatField(new GUIContent("Skill: "), (characterData as EmployeeData).skill, GUILayout.Height(smallControlHeight));
                (characterData as EmployeeData).speed = EditorGUILayout.FloatField(new GUIContent("Speed: "), (characterData as EmployeeData).speed, GUILayout.Height(smallControlHeight));

            }
            EditorGUILayout.EndVertical();
        }

        public void DrawCharacterDisplay(SerializedProperty _characterDataProperty)
        {

            if (_characterDataProperty == null)
            {

                return;
            }
            EditorGUILayout.BeginVertical(GUI.skin.GetStyle("HelpBox"), GUILayout.ExpandWidth(true));

            //Display base
            EditorGUILayout.PropertyField(_characterDataProperty, GUILayout.Height(smallControlHeight));

            EditorGUILayout.EndVertical();
        }

        public void DrawCharacterCreatorButtons()
        {
        }

        public void DrawCharacterCreator()
        {

            // EditorGUILayout.BeginHorizontal();
            DrawCharactersList();
            // DrawCharacterDisplay(characterDataBase);

            //EditorGUILayout.EndHorizontal();




            GUIStyle myStyle = GUI.skin.GetStyle("HelpBox");


            GUILayout.BeginVertical(myStyle);
            GUILayout.Label("Create New");
            sceneObject = (GameObject)EditorGUILayout.ObjectField(label: "SceneGo:", sceneObject, typeof(GameObject), true);

            if (sceneObject != null)
            {
                if (!displayObject)
                {
                    displayObject = !displayObject;
                }
                if (characterDataBase == null)
                {
                    InitCharacterData();
                }


                GUILayout.Label("kjsbgkj");



            }
            GUILayout.EndVertical();

        }

    }


}