using EditorTools;
using System;
using UnityEngine;

namespace ScriptableSystems
{
    [Serializable]
    [CreateAssetMenu(fileName = "BuildObjectDynamicParameterType", menuName = "ScriptableSystems/Build System/Build Object Dynamic Parameter Type")]

    public class BuildObjectDynamicParameterType : ScriptableObject
    {
        public string id;
        [EmployeeTypeSelector]
        public string employeeType;
    }
}