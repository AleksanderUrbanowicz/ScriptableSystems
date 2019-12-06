using EditorTools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;

namespace Characters
{

    [CreateAssetMenu(fileName = "CharactersConfig", menuName = "Characters/Characters Config")]

    public class CharactersConfig : ConfigBase
    {
        public static string Key = "CharactersConfig";

        public const float spaceFloat = 6.0f;

        public List<CharacterType> characterTypes = new List<CharacterType>();
        public List<EmployeeType> employeeTypes = new List<EmployeeType>();

        public List<GuestType> guestTypes = new List<GuestType>();

        public Color[] colorsSet;


        public OptionProperty option1 = new OptionProperty(true);
      //  public LabelledBool labelledBool = new LabelledBool();
        public List<LabelledBool> labelledBools = new List<LabelledBool>();


    }
}