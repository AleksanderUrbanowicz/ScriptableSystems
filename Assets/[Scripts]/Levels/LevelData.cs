using EditorTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Levels/Level Data")]

public class LevelData : ScriptableObject
{
    public string id;
    [SceneSelector]
    public string sceneName;
}
