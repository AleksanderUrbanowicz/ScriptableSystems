using EditorTools;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ScriptableSystems
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "NewBuildObjectData", menuName = "ScriptableSystems/Build System/Build Object Data")]
    public class BuildObjectData : ScriptableObject
    {

        public string id;

        public GameObject objectPrefab;
        public Vector3 offset;
        public Vector3 actualSize;
        public Vector3 gridSize;
        public Vector3 orientationVector;
        
        public int cost;
        public ObjectOrientation objectOrientation;
        public float rotationStep;
        public LayerMask layersToBuildOn;
        public LayerMask obstacleLayers;
        public float collsionBoundsFraction;
        static string prefabSuffix = "_prefab";

        public List<BuildObjectDynamicParameter> dynamicParameters;
        public List<BuildObjectStaticParameter> staticParameters;

       // [BuildObjectDynamicParameterTypeSelector]
        //public List<string> dynamicParameterTypes;

        //[BuildObjectStaticParameterTypeSelector]
       // public List<string> staticParameterTypes;
        public BuildObjectData()
        {
            objectOrientation = ObjectOrientation.FLOOR;
            orientationVector = Vector3.up;
            rotationStep = 90.0f;
            collsionBoundsFraction = 0.95f;
        }

        public void Initialize(GameObject obj)
        {


        }

        public void Destroy()
        {
            
         
        }

        private void OnEnable()
        {
            if (objectOrientation == ObjectOrientation.FLOOR)
            {
                orientationVector = Vector3.up;

            }
            else if (objectOrientation == ObjectOrientation.WALL)
            {
                orientationVector = Vector3.back;

            }
        }

    }
}
