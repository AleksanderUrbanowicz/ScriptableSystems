using UnityEngine;
using System.Collections;
using System;
using ScriptableSystems;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;

#endif
namespace EditorTools
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Settings/GameSettings")]

    [Serializable]
    public class GameSettings : ScriptableObject
    {
        public ScriptableBuildSystem scriptableBuildSystem;
        public ScriptableDataSystem scriptableDataSystem;
        public ScriptableSelectSystem scriptableSelectSystem;
        private BuildObjectData[] allObjectsArray;


        [BuildObjectSelector]
        public string defaultBuildObject;

        [BuildObjectCategorySelector]
        public string BuildObjectCategoryData;

        [SceneSelector]
        public string scene;

        [LevelSelector]
        public string level;

        [GameEventSelector]
        public string gameEvent;

        [ScriptableEventSelector]
        public string scriptableEvent;

        [ThemeUIDataSelector]
        public string uiThemeData;

        [CharacterTypeSelector]
        public string characterType;

        [EmployeeTypeSelector]
        public string employeeType;

        [GuestTypeSelector]
        public string guestType;

        [BuildObjectDynamicParameterTypeSelector]
        public string buildObjectDynamicParameterTypes;

        [BuildObjectStaticParameterTypeSelector]
        public string buildObjectStaticParameterTypes;

        private void OnEnable()
        {
#if UNITY_EDITOR
            allObjectsArray = EditorStaticTools.GetAllInstances<BuildObjectData>();
#endif
        }

        public BuildObjectData GetBuildObjectData(string _id)
        {

            for (int i = 0; i < allObjectsArray.Length; i++)
            {
                if (allObjectsArray[i].id == _id)
                {
                    return allObjectsArray[i];

                }

            }
            return new BuildObjectData();
        }
    }
}