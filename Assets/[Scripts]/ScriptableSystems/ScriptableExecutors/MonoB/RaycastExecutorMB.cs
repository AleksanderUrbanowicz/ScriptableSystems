using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableSystems
{
    public class RaycastExecutorMB : MonoBehaviour
    {
        public DefaultRaycastExecutor defaultRaycastExecutor;
        public int counter = 0;

        public void Init(DefaultRaycastExecutor scriptableSystem)
        {
            defaultRaycastExecutor = scriptableSystem;
            Debug.Log(defaultRaycastExecutor.id + ".OverrideInit,Type: " + this.GetType());
        }
        void Update()
        {
            if (defaultRaycastExecutor.updateInterval == 0)
            {
                return;
            }
            else
            {
                counter++;
            }
            counter++;


            if (defaultRaycastExecutor.updateInterval > 0 &&  defaultRaycastExecutor != null && counter>=defaultRaycastExecutor.updateInterval)
            {
                Debug.Log(defaultRaycastExecutor.id + ".Update().Execute " + this.gameObject.name);
                defaultRaycastExecutor.ExecuteMethod.Execute();
                counter = 0;
               // defaultRaycastExecutor.ExecuteMethod.Execute();
            }
          


        }
    }
}