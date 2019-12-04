
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;
using System;

namespace EditorTools

{
    public class SelectorPropertyAttribute : PropertyAttribute
    {
        protected Definitions definitionsConfig;
        protected string[] parameters;

        public delegate string[] GetStringList();
        public string[] Elements
        {
            get
            {
                if (parameters != null)
                {
                    return parameters;
                }

                UpdateParameters();
                return parameters;
            }
        }

        protected virtual void UpdateParameters()
        {
            /*
#if UNITY_EDITOR
            if (definitionsConfig == null)
            {
                definitionsConfig = EditorStaticTools.GetFirstInstance<Definitions>();
            }

#endif

            if (definitionsConfig != null)
            {

                parameters = definitionsConfig.gameEvents.Select(x => x.id).ToArray();

            }
            */
        }
    }


}




