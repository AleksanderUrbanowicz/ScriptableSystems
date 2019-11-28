﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectData 
{
    public string id;
    //public Vector3 position;
    // public Quaternion rotation;
    public float positionX;
    public float positionY;
    public float positionZ;

    public float rotationX;
    public float rotationY;
    public float rotationZ;
    public float rotationW;
    public ObjectData(string _id, Transform t)
    {
        id = _id;
        positionX = t.position.x;
        positionY = t.position.y;
        positionZ = t.position.z;

        rotationX = t.rotation.x;
        rotationY = t.rotation.y;
        rotationZ = t.rotation.z;
        rotationW = t.rotation.w;


    }
}
