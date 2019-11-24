using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ScriptableSystems
{
    [CreateAssetMenu(fileName = "DefaultRaycastExecutor", menuName = "ScriptableSystems/ScriptableExecutors/Default Raycast Executor")]

    public class DefaultRaycastExecutor : ScriptableExecutor
    {
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
            }

            // Debug.Log("Base ScriptableSystem.Initialize():+"+ obj.name);

            OnInitializedEvent.Raise();
        }
    }
}
