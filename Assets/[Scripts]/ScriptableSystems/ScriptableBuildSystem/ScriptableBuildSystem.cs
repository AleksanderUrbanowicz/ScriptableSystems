using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ScriptableSystems
{
    [CreateAssetMenu(fileName = "BuildSystem", menuName = "ScriptableSystems/Build System/System Asset")]
   public class ScriptableBuildSystem : ScriptableSystem

    {

        public LayerMask buildObjectLayer;
        public string buildObjectLayerString;

        public BuildObjectListData buildObjects;
        public Color availableColor = new Color(0, 1.0f, 0, 0.2f);
        public Color unavailableColor = new Color(1.0f, 0, 0, 0.2f);
        public Material previewMaterial;
        public ScriptableEvent EventPreviewRaycastHit;
        public ScriptableEvent EventPreviewRaycastMiss;
        public int raycastInterval=1;
        public bool logs;

        public override void Initialize(GameObject obj)
        {
            //base.Initialize(obj);
            obj.name = id;
            BuildSystemMonoBehaviour buildSystemMonoBehaviour = obj.AddComponent(monoBehaviourScript.GetClass()) as BuildSystemMonoBehaviour;
              if (buildSystemMonoBehaviour != null)
             {

                buildSystemMonoBehaviour.Init(this);
             }

            Debug.Log("override ScriptableBuildSystem.Initialize():" + obj.name);
            
            
        }
        public override void Deinitialize()
        {
           
            Debug.Log("override ScriptableBuildSystem.DeInitialize()"); 
        }

        public override void Start()
        {
            
            Debug.Log("override ScriptableBuildSystem.Start()" );

        }
        public override void Stop()
        {
            Debug.Log("override ScriptableBuildSystem.Stop()");

        }


  
    }
    
}