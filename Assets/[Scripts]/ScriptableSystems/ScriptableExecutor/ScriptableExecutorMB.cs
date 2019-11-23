using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableSystems
{
    public class ScriptableExecutorMB : MonoBehaviour
    {
        public ScriptableExecutor scriptableExecutorData;
      

        public virtual void Init(ScriptableExecutor scriptableSystem)
        {
            scriptableExecutorData = scriptableSystem;
            Debug.Log(scriptableExecutorData.id + ".OverrideInit,Type: " + this.GetType());
        }
         void Update()
        {
            Debug.Log(scriptableExecutorData.id + ".Update() " + this.gameObject.name);

            if (scriptableExecutorData != null)
            {

                scriptableExecutorData.ExecuteMethod.Execute();
            }

        }
        
    }
}
