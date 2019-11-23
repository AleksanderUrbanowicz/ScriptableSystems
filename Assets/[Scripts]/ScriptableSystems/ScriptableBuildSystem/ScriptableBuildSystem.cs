using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ScriptableSystems.BuildSystem
{
    [CreateAssetMenu(fileName = "BuildSystem", menuName = "ScriptableSystems/Build System/System Asset")]
    class ScriptableBuildSystem : ScriptableSystem

    {
        public BuildObjectListData buildObjects;
        public Color availableColor = new Color(0, 1.0f, 0, 0.2f);
        public Color unavailableColor = new Color(1.0f, 0, 0, 0.2f);
        public Material previewMaterial;

        //public new GameEvent OnInitialized;
       // public new BuildSystemEvent OnInitialized;
        
        public override void Initialize(GameObject obj)
        {
            base.Initialize(obj);

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