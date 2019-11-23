using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace ScriptableSystems
{

    // Class: ScriptableOnEventExecutor
    // Tool for calling ExecuteMethod.Execute() on ScriptableSystemEvent invoke

    [CreateAssetMenu(fileName = "ScriptableOnEventExecuteTool", menuName = "ScriptableSystems/ScriptableTools/Scriptable Execute Tool - On Event")]

    public class ScriptableOnEventExecutor : ScriptableExecutor
    {

      
        public ScriptableOnEventExecutor()
        {
            updateInterval = 0;
            scriptableExecuteType = ScriptableExecuteType.ON_EVENT;
        }

        public override void Initialize(GameObject obj)
        {
            base.Initialize(obj);

            Debug.Log("override ScriptableBuildSystem.Initialize():" + obj.name);
        }
        public override void Deinitialize()
        {
            Debug.Log("override ScriptableBuildSystem.DeInitialize()");
        }

        public override void Start()
        {
            Debug.Log("override ScriptableBuildSystem.Start()");

        }
        public override void Stop()
        {
            Debug.Log("override ScriptableBuildSystem.Stop()");

        }
    }

}
