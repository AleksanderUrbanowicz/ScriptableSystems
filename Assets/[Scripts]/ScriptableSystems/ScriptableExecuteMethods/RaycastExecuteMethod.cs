using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableSystems
{
    // Class: RaycastExecuteMethod
    // Simple raycast call, return values logged in console
    [CreateAssetMenu(fileName = "RaycastExecuteMethod", menuName = "ScriptableSystems/ScriptableExecutors/ Raycast ExecuteMethod")]

    public class RaycastExecuteMethod : ScriptableExecuteMethodBase
    {
        public RaycastInput raycastInput;
        public bool output;
        public RaycastHit raycastHit = new RaycastHit();
        public override void Execute()
        {

             output=Physics.Raycast(Vector3.up, Vector3.forward, out raycastHit, 10.0f, raycastInput.layerMask);
            
            Debug.Log("output"+ output);

        }
    }
}
