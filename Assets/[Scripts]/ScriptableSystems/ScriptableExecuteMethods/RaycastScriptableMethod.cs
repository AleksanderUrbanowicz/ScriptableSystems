#if (false) 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableSystems
{
    [CreateAssetMenu(fileName = "RaycastScriptableMethod", menuName = "ScriptableSystems/ScriptableMethods/Raycast Scriptable Method")]
    public class RaycastScriptableMethod : ScriptableMethod
    {
       // public RaycastHit[] outputRaycast+Hits;
        public override void Execute()
        {
            Debug.Log("RaycastScriptableMethod.id= " + id + ", desc=" + description);

        }
}
}
#endif