using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableSystems
{

    // Class: ScriptableExecutor
    // An abstract class to inherit from by future "Executor" Tools
    public abstract class  ScriptableExecutor : ScriptableSystem
    {
        public ScriptableExecuteMethodBase ExecuteMethod;
        public ScriptableEvent ExecuteOnEvent;
        //Change to define Execution type from interval and ExecuteOnEvent presence/absence ?
        public ScriptableExecuteType scriptableExecuteType;
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
    }

}
