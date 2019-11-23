using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableSystems
{
    [Serializable]
    [CreateAssetMenu(fileName = "NewBuildObjectCategoryData", menuName = "ScriptableSystems/Build System/Build Object Category Data")]

    public class BuildObjectCategoryData : ScriptableObject
    {
        public BuildObjectListData buildObjectListData;
    }
}