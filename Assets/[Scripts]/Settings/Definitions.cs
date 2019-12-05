﻿using Characters;
using Levels;
using ScriptableSystems;
using UnityEngine;

namespace EditorTools
{
    //[CreateAssetMenu(fileName = "Definitions", menuName = "Settings/Definitions")]
    public class Definitions : ScriptableObject
    {
        public BuildObjectData[] buildObjects;
        public BuildObjectCategoryData[] buildObjectCategories;
        public BuildObjectListData[] buildObjectLists;
        public GameEvent[] gameEvents;
        public ScriptableEvent[] scriptableEvents;
        public ThemeUIData[] uiThemes;
        public CharacterType[] characterTypes;
        public EmployeeType[] employeeTypes;
        public GuestType[] guestTypes;

        public LevelData[] levels;
        public BuildObjectDynamicParameterType[] buildObjectDynamicParameterTypes;
        public BuildObjectStaticParameterType[] buildObjectStaticParameterTypes;

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

            buildObjectDynamicParameterTypes = EditorStaticTools.GetAllInstances<BuildObjectDynamicParameterType>();
            buildObjectStaticParameterTypes = EditorStaticTools.GetAllInstances<BuildObjectStaticParameterType>();

#endif
        }

    }
}
