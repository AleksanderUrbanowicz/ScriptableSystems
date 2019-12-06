
using UnityEngine;
using System;
using System.Collections;
 
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property |
                AttributeTargets.Class | AttributeTargets.Struct, Inherited = true)]
public class ConditionalHideAttribute : PropertyAttribute
{
    
    public string ConditionFieldName = "";
    
    public bool HideInInspector = false;
 
    public ConditionalHideAttribute(string conditionFieldName)
    {
        this.ConditionFieldName = ConditionFieldName;
        this.HideInInspector = false;
    }
 
    public ConditionalHideAttribute(string conditionFieldName, bool hideInInspector)
    {
        this.ConditionFieldName = conditionFieldName;
        this.HideInInspector = hideInInspector;
    }
}