using EditorTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Characters
{
    [CreateAssetMenu(fileName = "EmployeeData", menuName = "Characters/Employee Data")]

    public class EmployeeData : CharacterDataBase
    {
        
        [EmployeeTypeSelector]
        public string employeeType;
        public float wage;

       
    }
}