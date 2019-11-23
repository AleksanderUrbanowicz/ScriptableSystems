using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ScriptableSystems
{
    public abstract class ScriptableSystem : ScriptableObject
    {
        public string id;

        public bool initializeOnStart;

        public MonoScript monoBehaviourScript;

        public ScriptableEvent OnInitializedEvent;
        public ScriptableEvent OnStartEvent;
        public ScriptableEvent OnStopEvent;
        public virtual void Initialize(GameObject obj)
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

           

            OnInitializedEvent.Raise();
        }

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

    }
}