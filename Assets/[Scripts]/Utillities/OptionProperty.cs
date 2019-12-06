using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EditorTools
{
    [Serializable]
    public class OptionProperty
    {
        [SerializeField] public bool option;
        [SerializeField] public bool defaultOption;

        public OptionProperty(bool _defaultOption)
        {
            defaultOption = _defaultOption;
            option = _defaultOption;
        }

        public OptionProperty()
        {
        }

  
    }
}