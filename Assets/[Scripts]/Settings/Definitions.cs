using Characters;
using Levels;
using ScriptableSystems;
using UnityEngine;

namespace EditorTools
{
    //[CreateAssetMenu(fileName = "Definitions", menuName = "Settings/Definitions")]
    public class Definitions : ConfigBase
    {
        public static string Key = "DefinitionsConfig";
        public MaterialType[] materialTypes;
        public ObjectType[] objectTypes;
        
        public BuildObjectData[] buildObjects;
        public BuildObjectCategoryData[] buildObjectCategories;
        public BuildObjectListData[] buildObjectLists;
        public GameEvent[] gameEvents;
        public ScriptableEvent[] scriptableEvents;
        public ThemeUIData[] uiThemes;
        public BuildObjectMaterialSet[] materialSets;

        public LevelData[] levels;
        public BuildObjectDynamicParameterType[] buildObjectDynamicParameterTypes;
        public HotelParameterType[] hotelParameterTypes;

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
            materialSets = EditorStaticTools.GetAllInstances<BuildObjectMaterialSet>();

            levels = EditorStaticTools.GetAllInstances<LevelData>();

            buildObjectDynamicParameterTypes = EditorStaticTools.GetAllInstances<BuildObjectDynamicParameterType>();
            hotelParameterTypes = EditorStaticTools.GetAllInstances<HotelParameterType>();

#endif
        }

    }
}
