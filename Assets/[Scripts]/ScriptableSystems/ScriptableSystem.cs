using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
//#if UNITY_EDITOR
namespace ScriptableSystems
{
    public abstract class ScriptableSystem : ScriptableObject
    {
        public string id;

        public bool initializeOnStart;

        //public MonoScript monoBehaviourScript;
        public MonoBehaviour monoBehaviourScript;
        private ScriptableEvent OnInitializedEvent;
        private ScriptableEvent OnStartEvent;
        private ScriptableEvent OnStopEvent;
        public virtual void Initialize(GameObject obj)
        { 
             obj.name = id;
            
            if (monoBehaviourScript != null)
            {
               // MonoBehaviour scriptableSystemMB = obj.AddComponent(monoBehaviourScript.GetClass()) as MonoBehaviour;
              //  if (scriptableSystemMB != null)
               // {

                   // scriptableSystemMB.Init(this);
               // }
            }
            

           

            OnInitializedEvent.Raise();
        }
        /*
        public virtual void Deinitialize()
        {
            //   Debug.Log("ScriptableExecutor.Deinitialize");

        }
        public virtual void Start()
        {

            Debug.Log("ScriptableExecutor.Start");

        }
        public virtual void Stop()
        {
            Debug.Log("ScriptableExecutor.Stop");


        }
        */
    }
}
//#endif