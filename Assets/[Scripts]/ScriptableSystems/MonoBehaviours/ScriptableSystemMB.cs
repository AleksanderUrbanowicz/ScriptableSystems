using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableSystems
{
    public  class ScriptableSystemMB : MonoBehaviour
    {
        public ScriptableSystem scriptableSystemData;
        public virtual  void Init(ScriptableSystem scriptableSystem)
        {
            scriptableSystemData = scriptableSystem;
            //Debug.Log(scriptableSystemData.id + ".InitBase,Type: "+this.GetType());
        }

        private void Update()
        {
            //Debug.Log(scriptableSystemData.id);
        }

    }
}
