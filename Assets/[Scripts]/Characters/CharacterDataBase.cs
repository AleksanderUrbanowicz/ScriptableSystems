using EditorTools;
using UnityEngine;

namespace Characters
{
    public class CharacterDataBase : ScriptableObject
    {
        public string id;
        [CharacterTypeSelector]
        public string characterType;
        //Name + surname ?
        public string displayName;
        public GameObject prefab;
    }
}