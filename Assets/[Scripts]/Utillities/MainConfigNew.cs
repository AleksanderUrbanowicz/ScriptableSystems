using Characters;
using EditorTools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;

namespace EditorTools
{

    [CreateAssetMenu(fileName = "MainConfigNew", menuName = "Config/Main Config")]

    public class MainConfigNew : ConfigBase
    {
        public static string Key = "MainConfig";

        public const float spaceFloat = 6.0f;

        public List<CharacterType> characterTypes = new List<CharacterType>();
        public List<EmployeeType> employeeTypes = new List<EmployeeType>();
        public List<GuestType> guestTypes = new List<GuestType>();

        public List<EmployeeData> employeeDatas = new List<EmployeeData>();
        public List<GuestData> guestDatas = new List<GuestData>();
        public List<CharacterDataBase> characterDatas = new List<CharacterDataBase>();

        public Color[] colorsSet;
        public Color guestColor;
        public Color employeeColor;

        public OptionProperty option1 = new OptionProperty(true);
        public List<LabelledBool> labelledBools = new List<LabelledBool>();

        public bool generatorTabOpen;
        public bool colorsCustomizerTabOpen;
        public bool definitionsTabOpen;


        private void OnEnable()
        {
            OnEnableMethod();
        }

        public void OnEnableMethod()
        {
#if UNITY_EDITOR

            employeeDatas = EditorStaticTools.GetAllInstances<EmployeeData>().ToList();
            guestDatas = EditorStaticTools.GetAllInstances<GuestData>().ToList();
            characterDatas = EditorStaticTools.GetAllInstances<CharacterDataBase>().ToList();

#endif
        }

    }
}