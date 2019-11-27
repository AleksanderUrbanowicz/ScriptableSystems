using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ScriptableSystems
{
    [CreateAssetMenu(fileName = "BuildSystem", menuName = "ScriptableSystems/Build System/System Asset")]
   public class ScriptableBuildSystem : ScriptableSystem

    {
        public BuildObjectListData buildObjects;
        public Color availableColor = new Color(0, 1.0f, 0, 0.2f);
        public Color unavailableColor = new Color(1.0f, 0, 0, 0.2f);
        public Material previewMaterial;
        
      //  public Transform cam;
       // public Transform buildObjectsParent;
       // private RaycastHit raycastHit;
      //  public BuildSystemRaycast defaultRaycast;

        //public new GameEvent OnInitialized;
       // public new BuildSystemEvent OnInitialized;
        
        public override void Initialize(GameObject obj)
        {
            //base.Initialize(obj);
            obj.name = id;
            BuildSystemMonoBehaviour buildSystemMonoBehaviour = obj.AddComponent(monoBehaviourScript.GetClass()) as BuildSystemMonoBehaviour;
              if (buildSystemMonoBehaviour != null)
             {

                buildSystemMonoBehaviour.Init(this);
             }
            
           // scriptableSystemMB.Init(this);
            // cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
            Debug.Log("override ScriptableBuildSystem.Initialize():" + obj.name);
            // InitializeRaycaster();
            
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


        public void InitializeRaycaster()
        {
/*
            if (defaultRaycast.initializeOnStart)
            {
                GameObject systemGO = new GameObject();
                
                defaultRaycast.Initialize(systemGO);
                RaycastExecuteMethod raycastMethod = (defaultRaycast.ExecuteMethod as RaycastExecuteMethod);
                raycastMethod.raycastInput.transformToFollow = cam.transform;
                raycastMethod.raycastInput.layerMask = LayerMask.NameToLayer("Floor");
            }
            */
        }
    }
    
}