using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableSystems
{

    // Class: ScriptableExecuteMethodBase
    // An abstract class to inherit from by future ExecuteMethod types in next "Executors"  
    public abstract class ScriptableExecuteMethodBase : ScriptableObject
    {
        public string id;
        public string description;
        public abstract void Execute();

    }
}