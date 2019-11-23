using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ScriptableSystems
{
    public struct RaycastInput 
    {
        Transform transformToFollow;
        LayerMask layerMask;
        //read from asset ?
        float raycastDistance;
    }
}
