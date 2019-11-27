using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ScriptableSystems
{
    [CreateAssetMenu(fileName = "DefaultRaycastExecutor", menuName = "ScriptableSystems/ScriptableExecutors/Default Raycast Executor")]

    public class DefaultRaycastExecutor : ScriptableExecutor
    {
        public Transform target;
        public LayerMask layer;

        public override void Initialize(GameObject obj)
        {
            obj.name = id;

            if (monoBehaviourScript != null)
            {

                RaycastExecutorMB scriptableSystemMB = obj.AddComponent(monoBehaviourScript.GetClass()) as RaycastExecutorMB;


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
                GameObject MBInstance = GameObject.Instantiate(prefab, obj.transform);
                RaycastExecutorMB scriptableSystemMB = MBInstance.GetComponent<RaycastExecutorMB>();

                if (scriptableSystemMB != null)
                {

                    scriptableSystemMB.Init(this,target,layer);
                  
                }
               
            }


            OnInitializedEvent.Raise();
        }

        public override void Start()
        {
            base.Start();
        }

        public override void Stop()
        {
            base.Stop();
        }
    }
}
