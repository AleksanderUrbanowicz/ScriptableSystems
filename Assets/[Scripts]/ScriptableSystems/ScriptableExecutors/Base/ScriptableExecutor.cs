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

        public GameObject prefab;
        public int updateInterval;

        public bool isExecuting;
        public override void Initialize(GameObject obj)
        {
            obj.name = id;

            if (monoBehaviourScript != null)
            {

                ScriptableExecutorMB scriptableSystemMB = obj.AddComponent(monoBehaviourScript.GetClass()) as ScriptableExecutorMB;


                if (scriptableSystemMB != null)
                {

                    scriptableSystemMB.Init(this);
                }
                GameEventListener gameEventStartListener = obj.AddComponent<GameEventListener>();
                gameEventStartListener.Event = EventToStart;
                // gameEventStartListener.Response = Start;

            }
            else
            {
              GameObject MBInstance=  GameObject.Instantiate(prefab, obj.transform);
                ScriptableExecutorMB scriptableSystemMB = MBInstance.GetComponent<ScriptableExecutorMB>();

                if (scriptableSystemMB != null)
                {

                    scriptableSystemMB.Init(this);
                }
                //GameEventListener gameEventStartListener = obj.AddComponent<GameEventListener>();
              //  gameEventStartListener.Event = EventToStart;
                // gameEventStartListener.Response = Start;
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
            isExecuting = true;
               Debug.Log("ScriptableExecutor.Start");

        }
        public virtual void Stop()
        {
            isExecuting = false;
            Debug.Log("ScriptableExecutor.Stop");


        }

    }

}
