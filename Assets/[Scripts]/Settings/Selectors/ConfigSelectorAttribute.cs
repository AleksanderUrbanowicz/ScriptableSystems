using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace EditorTools
{
    public class ConfigSelectorAttribute : PropertyAttribute
    {
        protected  string key;
        protected ConfigBase config;
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
            
#if UNITY_EDITOR
   if (config == null)
   {
                //configBase = EditorStaticTools.GetFirstInstance<Definitions>();
                ConfigBase[] configs = EditorStaticTools.GetAllInstances<ConfigBase>();
                if(configs!=null && configs.Length>0)
                {
                    for (int i=0;i < configs.Length;i++)
                    {
                        if (key == configs[i].key)
                        {
                            config = configs[i];

                        }

                    }

                }
                
            }

#endif
   /*
   if (configBase != null)
   {

       parameters = configBase.gameEvents.Select(x => x.id).ToArray();

   }
   */
        }
    }
}