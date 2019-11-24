#if (false) 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableSystems
{

    // Class: SimpleInvokeExecuteMethod
    // Simple executeMethod example 
    [CreateAssetMenu(fileName = "SimpleInvokeExecuteMethod", menuName = "ScriptableSystems/ScriptableMethods/Execute Method Example")]
    public class SimpleInvokeExecuteMethod : ScriptableExecuteMethodBase
        {
        public override void Execute()
        {

            Debug.Log("SimpleInvokeExecuteMethod.Execute()");

        }
    }
    
}
#endif