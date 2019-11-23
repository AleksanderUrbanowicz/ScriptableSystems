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
        public abstract void Deinitialize();
        public abstract void Start();
        public abstract void Stop();
        //Base GameEvents ? 
    }
}