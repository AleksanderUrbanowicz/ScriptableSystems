using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ScriptableSystems
{
    // Class: CustomScriptableSystemMB
    //  MonoBehaviour "hookup" script for scene representation of ScriptableBuildSystem hierarchy level
    public class ScriptableBuildSystemMB : ScriptableSystemMB
    {
        public override void Init(ScriptableSystem scriptableSystem)
        {
            scriptableSystemData = scriptableSystem;
           // Debug.Log(scriptableSystemData.id + ".OverrideInit,Type: " + this.GetType());
        }

    }
}
