﻿using EditorTools;
using UnityEngine;

namespace Characters
{
    [CreateAssetMenu(fileName = "EmployeeData", menuName = "Characters/Employee Data")]

    public class EmployeeData : CharacterDataBase
    {
        
        
        [EmployeeTypeSelector]
        public string employeeType;
        public float salary;
        [RangeAttribute(0.0f,100.0f)]
        public float skill;
        [RangeAttribute(0.0f, 10.0f)]
        public float speed;


        public EmployeeData()
        {
            base.characterType = "Employee";
        }

    }
}