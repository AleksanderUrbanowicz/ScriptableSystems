﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableSystems
{
    public class RaycastExecutorMB : ScriptableExecutorMB
    {
        public DefaultRaycastExecutor defaultRaycastExecutor;
       

        public ScriptableSystemEventListener startListener;
        public ScriptableSystemEventListener stopListener;

        public void Init(DefaultRaycastExecutor scriptableSystem)
        {
            defaultRaycastExecutor = scriptableSystem;
            startListener.Event = defaultRaycastExecutor.OnStartEvent;
            stopListener.Event = defaultRaycastExecutor.OnStopEvent;
            Debug.Log(defaultRaycastExecutor.id + ".OverrideInit,Type: " + this.GetType());
            startListener.Validate();
            stopListener.Validate();
            defaultRaycastExecutor.isExecuting = false;
        }
        void Update()
        {
           if(defaultRaycastExecutor==null)
            {
                return;

            }
            
            if (defaultRaycastExecutor.updateInterval == 0 || !defaultRaycastExecutor.isExecuting)
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
               // Debug.Log(defaultRaycastExecutor.id + ".Update().Execute " + this.gameObject.name);
                defaultRaycastExecutor.ExecuteMethod.Execute();
                //defaultRaycastExecutor.ExecuteMethod
                counter = 0;
 
            }
         
        }

        public void StartExecute()
        {
             Debug.Log(defaultRaycastExecutor.id + "StartExecute:  " + this.gameObject.name);
            defaultRaycastExecutor.Start();

        }


        public void StopEecute()
        {

            Debug.Log(defaultRaycastExecutor.id + "StopExecute:  " + this.gameObject.name);

            defaultRaycastExecutor.Stop();
        }

        public override void UpdateMethod()
        {
            Debug.Log(scriptableExecutorData.id + ".Update().Execute " + this.gameObject.name);

            if (scriptableExecutorData == null || scriptableExecutorData.updateInterval == 0)
            {
                return;
            }
            else
            {
                counter++;
            }
            // counter++;


            if (scriptableExecutorData.updateInterval > 0 && counter >= scriptableExecutorData.updateInterval)
            {
                Debug.Log(scriptableExecutorData.id + ".Update().Execute " + this.gameObject.name);
                scriptableExecutorData.ExecuteMethod.Execute();
                counter = 0;
                 defaultRaycastExecutor.ExecuteMethod.Execute();
            }

        }
    }
}