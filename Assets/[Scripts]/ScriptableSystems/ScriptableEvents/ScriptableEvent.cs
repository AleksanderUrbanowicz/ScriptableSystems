using System.Collections.Generic;
using UnityEngine;

namespace ScriptableSystems
{

    [CreateAssetMenu(fileName = "ScriptableSystemEvent", menuName = "ScriptableSystems/Scriptable System Event")]

    public class ScriptableEvent : ScriptableObject
    {

            /// <summary>
            /// The list of listeners that this event will notify if it is raised.
            /// </summary>
            private readonly List<ScriptableSystemEventListener> eventListeners =
                new List<ScriptableSystemEventListener>();

            public virtual void Raise()
            {
                for (int i = eventListeners.Count - 1; i >= 0; i--)
                    eventListeners[i].OnEventRaised();
            }

            public virtual void RegisterListener(ScriptableSystemEventListener listener)
            {
                if (!eventListeners.Contains(listener))
                    eventListeners.Add(listener);
            }

            public virtual void UnregisterListener(ScriptableSystemEventListener listener)
            {
                if (eventListeners.Contains(listener))
                    eventListeners.Remove(listener);
            }
        }
    }

