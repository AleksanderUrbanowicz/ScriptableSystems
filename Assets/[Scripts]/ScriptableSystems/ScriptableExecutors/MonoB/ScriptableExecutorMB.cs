using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableSystems
{
    public class ScriptableExecutorMB : MonoBehaviour
    {
        public ScriptableExecutor scriptableExecutorData;
        public int counter;

        public  void Init(ScriptableExecutor scriptableSystem)
        {
            scriptableExecutorData = scriptableSystem;
            Debug.Log(scriptableExecutorData.id + ".OverrideInit,Type: " + this.GetType());
        }

        public virtual void UpdateMethod()
        {
           // Debug.Log(scriptableExecutorData.id + ".Update().Execute " + this.gameObject.name);

            if (scriptableExecutorData == null || scriptableExecutorData.updateInterval == 0)
            {
                return;
            }
            else
            {
                counter++;
            }
           // counter++;


            if (scriptableExecutorData.updateInterval > 0 &&  counter >= scriptableExecutorData.updateInterval)
            {
                Debug.Log(scriptableExecutorData.id + ".Update().Execute " + this.gameObject.name);
                scriptableExecutorData.ExecuteMethod.Execute();
                counter = 0;
                // defaultRaycastExecutor.ExecuteMethod.Execute();
            }

        }

        void Update()
        {

            UpdateMethod();
            /*
            if (scriptableExecutorData == null || scriptableExecutorData.updateInterval == 0)
            {
                return;
            }
            else
            {
                counter++;
            }
            counter++;
            

            if (scriptableExecutorData.updateInterval > 0 && scriptableExecutorData != null && counter >= scriptableExecutorData.updateInterval)
            {
                Debug.Log(scriptableExecutorData.id + ".Update().Execute " + this.gameObject.name);
                scriptableExecutorData.ExecuteMethod.Execute();
                counter = 0;
                // defaultRaycastExecutor.ExecuteMethod.Execute();
            }
            */
        }

    }
}
