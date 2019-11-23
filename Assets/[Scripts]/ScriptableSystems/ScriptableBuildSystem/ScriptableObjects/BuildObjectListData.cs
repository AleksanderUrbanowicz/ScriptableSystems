﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ScriptableSystems
{
    [Serializable]
    [CreateAssetMenu(fileName = "NewBuildObjectListData", menuName = "ScriptableSystems/Build System/Build Object List Data")]

    public class BuildObjectListData : ScriptableObject
    {
        public List<BuildObjectData> items;
    }
}