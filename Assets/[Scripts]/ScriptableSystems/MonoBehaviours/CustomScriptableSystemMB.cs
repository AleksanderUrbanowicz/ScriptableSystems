using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableSystems
{
    // Class: CustomScriptableSystemMB
    //  MonoBehaviour "hookup" script for scene representation of ScriptableSystem hierarchy level
    public class CustomScriptableSystemMB : ScriptableSystemMB
    {
        public override void Init(ScriptableSystem scriptableSystem)
        {
            scriptableSystemData = scriptableSystem;
            Debug.Log(scriptableSystemData.id + ".OverrideInit,Type: " + this.GetType());
        }
    }
}
