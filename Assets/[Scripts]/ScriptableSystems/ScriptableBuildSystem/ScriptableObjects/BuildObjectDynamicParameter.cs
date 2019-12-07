using EditorTools;
using System;

namespace ScriptableSystems
{
    [Serializable]
    public class BuildObjectDynamicParameter : DynamicParameter
    {
        [BuildObjectDynamicParameterTypeSelector]
        public string parameterType;
    }
}