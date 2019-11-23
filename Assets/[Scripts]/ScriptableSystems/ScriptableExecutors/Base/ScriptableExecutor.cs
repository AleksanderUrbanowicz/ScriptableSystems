using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableSystems
{

    // Class: ScriptableExecutor
    // nope`
    public abstract class  ScriptableExecutor : ScriptableSystem
    {
        public ScriptableExecuteMethodBase ExecuteMethod;
        public GameEvent ExecuteOnEvent;
        //public GameObject prefab;
        public int updateInterval;

        public override void Initialize(GameObject obj)
        {
            obj.name = id;

            if (monoBehaviourScript != null)
            {

                ScriptableSystemMB scriptableSystemMB = obj.AddComponent(monoBehaviourScript.GetClass()) as ScriptableSystemMB;
                if (scriptableSystemMB != null)
                {

                    scriptableSystemMB.Init(this);
                }
            }

            // Debug.Log("Base ScriptableSystem.Initialize():+"+ obj.name);

            OnInitializedEvent.Raise();
        }

        public override  void Deinitialize()
        {
            Debug.Log("ScriptableExecutor.Deinitialize");
            
        }
        public override void  Start()
        {

               Debug.Log("ScriptableExecutor.Start");

        }
        public override void Stop()
        {
            Debug.Log("ScriptableExecutor.Stop");


        }

    }

}
