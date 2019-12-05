using EditorTools;
using System;

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

