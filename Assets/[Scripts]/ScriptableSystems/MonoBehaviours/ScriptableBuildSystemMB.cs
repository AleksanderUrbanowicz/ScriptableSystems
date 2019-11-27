using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ScriptableSystems
{
    // Class: CustomScriptableSystemMB
    //  MonoBehaviour "hookup" script for scene representation of ScriptableBuildSystem hierarchy level
    public class ScriptableBuildSystemMB : MonoBehaviour
    {


        private void Start()
        {
            Debug.Log("ScriptableBuildSystemMB. Start()");
        }

        public void Init(ScriptableBuildSystem scriptableBuildSystem)
        {
            Debug.Log("ScriptableBuildSystemMB. Init(): "+ scriptableBuildSystem.id);

        }

    }
}
