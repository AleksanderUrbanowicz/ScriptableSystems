using EditorTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Characters
{
    [CreateAssetMenu(fileName = "GuestData", menuName = "Characters/Guest Data")]
    public class GuestData : CharacterDataBase
    {
        [GuestTypeSelector]
        public string GuestType;
    }
}