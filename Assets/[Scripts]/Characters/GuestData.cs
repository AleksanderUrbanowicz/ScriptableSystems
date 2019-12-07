using EditorTools;
using ScriptableSystems;
using System.Collections.Generic;
using UnityEngine;

namespace Characters
{
    [CreateAssetMenu(fileName = "GuestData", menuName = "Characters/Guest Data")]
    public class GuestData : CharacterDataBase
    {
        [GuestTypeSelector]
        public string GuestType;
        //additional requirements, besides requirements based on GuestType
        public List<HotelParameter> requirements = new List<HotelParameter>(); 
        
        public GuestData()
        {
            characterType = "Guest";
        }

    }
}