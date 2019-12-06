using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EditorTools
{
    [Serializable]
    public class LabelledBool 
    {
        
        public string id;
        public bool val;

        public LabelledBool()
        {
            id = "";
            val = false;
        }
    }
}