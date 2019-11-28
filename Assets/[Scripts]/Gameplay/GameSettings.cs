using UnityEngine;
using System.Collections;
using System;
using ScriptableSystems;
[CreateAssetMenu(fileName = "GameSettings", menuName = "Settings/GameSettings")]

[Serializable]
public class GameSettings : ScriptableObject
{
    public ScriptableBuildSystem scriptableBuildSystem;
    public ScriptableDataSystem scriptableDataSystem;

    

}