using EditorTools;
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