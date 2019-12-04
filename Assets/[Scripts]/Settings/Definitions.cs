using ScriptableSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    //[CreateAssetMenu(fileName = "Definitions", menuName = "Settings/Definitions")]
public class Definitions : ScriptableObject
    {
        public BuildObjectData[] buildObjects;
        public BuildObjectCategoryData[] buildObjectCategories;
        public BuildObjectListData[] buildObjectLists;
        public GameEvent[] gameEvents;
        public ScriptableEvent[] scriptableEvents;
        public ThemeUIData[] uiThemes;
        public EmployeeType[] employeeTypes;
        public LevelData[] levels;
        private void OnEnable()
        {
            OnEnableMethod();
        }

        public void OnEnableMethod()
        {
#if UNITY_EDITOR
            buildObjects = EditorStaticTools.GetAllInstances<BuildObjectData>();
            buildObjectCategories = EditorStaticTools.GetAllInstances<BuildObjectCategoryData>();
            buildObjectLists = EditorStaticTools.GetAllInstances<BuildObjectListData>();

            gameEvents = EditorStaticTools.GetAllInstances<GameEvent>();
            scriptableEvents = EditorStaticTools.GetAllInstances<ScriptableEvent>();

            uiThemes = EditorStaticTools.GetAllInstances<ThemeUIData>();

            levels = EditorStaticTools.GetAllInstances<LevelData>();
#endif
    }
    }
