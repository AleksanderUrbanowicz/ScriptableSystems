using EditorTools;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableSystems
{
    [Serializable]
    public class BuildObjectDynamicParameter
    {
        [BuildObjectDynamicParameterTypeSelector]
        public string parameterType;
        public float initValue;
        public float decreaseRate;
    }
}