using EditorTools;
using System;
using System.Collections.Generic;

namespace Characters
{
    [Serializable]
    public class EmployeeType
    {
        public string id;

        [BuildObjectDynamicParameterTypeSelector]
        public List<string> affectedParameters;
    }
}