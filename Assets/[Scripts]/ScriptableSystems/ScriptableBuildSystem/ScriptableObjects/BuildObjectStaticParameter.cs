using EditorTools;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableSystems
{
    [Serializable]
    public class BuildObjectStaticParameter
    {
        [BuildObjectStaticParameterTypeSelector]
        public string parameterType;

        public int value;
    }
}

