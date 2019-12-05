using EditorTools;
using System;

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