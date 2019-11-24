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

        public GameEvent EventToStart;
        public GameEvent EventToStop;

        //public GameObject prefab;
        public int updateInterval;

        public bool isStarted;
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
                GameEventListener gameEventListener = obj.AddComponent<GameEventListener>();
                gameEventListener.Event = EventToStart;
                

            }

            // Debug.Log("Base ScriptableSystem.Initialize():+"+ obj.name);

            OnInitializedEvent.Raise();
        }

        public virtual  void Deinitialize()
        {
            Debug.Log("ScriptableExecutor.Deinitialize");
            
        }
        public virtual void  Start()
        {

               Debug.Log("ScriptableExecutor.Start");

        }
        public virtual void Stop()
        {
            Debug.Log("ScriptableExecutor.Stop");


        }

    }

}
