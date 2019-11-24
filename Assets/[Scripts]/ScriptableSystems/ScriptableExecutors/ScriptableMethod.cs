#if (false)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ScriptableSystems
{
    //[CreateAssetMenu(fileName = "NewScriptableMethod", menuName = "ScriptableSystems/ScriptableMethod")]


    public abstract class ScriptableMethod : ScriptableObject
    {
        public string id;
        public string description;
        public abstract void Execute();
        
    }
}
#endif