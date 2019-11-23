using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableSystems
{
    [CreateAssetMenu(fileName = "ScriptableSystem", menuName = "ScriptableSystems/Custom System/System Asset")]
    public class CustomScriptableSystem : ScriptableSystem
    {
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
        }
        public override void Deinitialize()
        {
            Debug.Log("override CustomScriptableSystem.DeInitialize()");
        }

        public override void Start()
        {
            Debug.Log("override CustomScriptableSystem.Start()");

        }
        public override void Stop()
        {
            Debug.Log("override CustomScriptableSystem.Stop()");

        }



    }
}