using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ScriptableSystems
{
    public class ScriptableToolMB : MonoBehaviour
    {
        public ScriptableToolBase scriptableToolBaseData;

        private void Update()
        {
        
            if(scriptableToolBaseData!=null)
            {

                scriptableToolBaseData.ExecuteMethod.Execute();
            }

        }
    }
}