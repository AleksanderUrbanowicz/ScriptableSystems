using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableSystems
{
    public class ScriptableExecutorMB : MonoBehaviour
    {
        public ScriptableExecutor scriptableExecutorData;
      

        public  void Init(ScriptableExecutor scriptableSystem)
        {
            scriptableExecutorData = scriptableSystem;
            Debug.Log(scriptableExecutorData.id + ".OverrideInit,Type: " + this.GetType());
        }
         void Update()
        {
            

            if (scriptableExecutorData != null)
            {
                Debug.Log(scriptableExecutorData.id + ".Update().Execute " + this.gameObject.name);

                scriptableExecutorData.ExecuteMethod.Execute();
            }
            
        }
        
    }
}
