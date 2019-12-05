using EditorTools;
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