using EditorTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Characters
{
    public class CharacterDataBase : ScriptableObject
    {
        public string id;
        [CharacterTypeSelector]
        public string characterType;
        public GameObject prefab;
    }
}