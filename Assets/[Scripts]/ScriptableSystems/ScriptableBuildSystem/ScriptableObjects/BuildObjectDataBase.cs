using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableSystems.BuildSystem
{
    class BuildObjectDataBase : ScriptableObject
    {
        public GameObject objectPrefab;
        public Vector3 offset;
        public Vector3 actualSize;
        public Vector3 gridSize;
        public Vector3 orientationVector;
    }
}
