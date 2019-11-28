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
        

    }
}
