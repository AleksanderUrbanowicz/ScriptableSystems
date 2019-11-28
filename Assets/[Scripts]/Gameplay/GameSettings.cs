using UnityEngine;
using System.Collections;
using System;
using ScriptableSystems;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Settings/GameSettings")]

[Serializable]
public class GameSettings : ScriptableObject
{
    public ScriptableBuildSystem scriptableBuildSystem;
    public ScriptableDataSystem scriptableDataSystem;
    public BuildObjectData[] allObjectsArray;
   // public List<BuildObjectData> allObjects;

    private void OnEnable()
    {
        allObjectsArray = EditorTools.GetAllInstances<BuildObjectData>();
    }

    public BuildObjectData GetBuildObjectData(string _id)
    {

        for(int i=0;i< allObjectsArray.Length;i++)
        {
            if(allObjectsArray[i].id==_id)
            {
                return allObjectsArray[i];

            }

        }
        return new BuildObjectData();
    }
}