using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableSystems
{
    // Class: RaycastExecuteMethod
    // Simple raycast call, return values logged in console
    public class RaycastExecuteMethod : ScriptableExecuteMethodBase
    {

        public RaycastHit raycastHit = new RaycastHit();
        public override void Execute()
        {

            Debug.Log(Physics.Raycast(Vector3.up, Vector3.forward, out raycastHit, 10.0f, LayerMask.NameToLayer("Floor"))); 

        }
    }
}
