using System.Linq;
using UnityEngine;

namespace EditorTools

{
    public class CharactersSelectorPropertyAttribute : PropertyAttribute
        {
            protected MainConfigNew charactersConfig;
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

                    affectedParameters = definitionsConfig.gameEvents.Select(x => x.id).ToArray();

                }
                */
            }
        }
    }

    










