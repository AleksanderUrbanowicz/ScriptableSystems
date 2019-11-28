﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class ThemeUISpawner : Editor
{
  [MenuItem("GameObject/ThemeUI/Button", priority =0)]
  public static void AddButton()
    {
        Create("ThemeButton");

    }

    [MenuItem("GameObject/ThemeUI/Panel", priority = 0)]

    public static void AddPanel()
    {
        Create("ThemePanel");

    }

    public static GameObject selectedObject;

    private static GameObject Create(string name)
    {
        GameObject instance = Instantiate(Resources.Load<GameObject>(name));
        instance.name = name;
        selectedObject = UnityEditor.Selection.activeObject as GameObject;
        if(selectedObject!=null)
        {
            instance.transform.SetParent( selectedObject.transform,false);

        }

        return instance;

    }
}
