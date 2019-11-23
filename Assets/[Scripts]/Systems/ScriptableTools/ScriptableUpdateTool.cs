using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ScriptableSystems
{
    [CreateAssetMenu(fileName = "ScriptableUpdateTool", menuName = "ScriptableSystems/Scriptable Update Tool")]

    public class ScriptableUpdateTool : ScriptableToolBase
    {

        public int updateInterval = 3;
    }
}