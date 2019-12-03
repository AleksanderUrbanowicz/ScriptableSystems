﻿using ScriptableSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerHelper : MonoBehaviour
{
    public Transform parentTransform;


    public void Init()
    {
        parentTransform = new GameObject("BuildObjects").transform;
        GameManager.instance.spawnerHelper = this;
    }
    public void SpawnObject(ObjectData od)
    {
        BuildObjectData buildObjectData = GameManager.instance.settings.GetBuildObjectData(od.id);
        if(buildObjectData.id!= od.id)
        {
            return;

        }
        Vector3 position = new Vector3(od.positionX, od.positionY, od.positionZ);
        Quaternion rotation = new Quaternion(od.rotationX, od.rotationY, od.rotationZ, od.rotationW);
      GameObject go=  Instantiate(buildObjectData.objectPrefab, position, rotation, parentTransform);
        // layer and tag to save loaded objects
        //go.layer=GameManager.instance.buildSystemMonoBehaviour
    }
    public void SpawnObject(string _id, Vector3 position, Quaternion rotation)
    {
        BuildObjectData buildObjectData= GameManager.instance.settings.GetBuildObjectData(_id);
        Instantiate(buildObjectData.objectPrefab, position, rotation, parentTransform);

    }
}
