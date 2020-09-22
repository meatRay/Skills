using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDataScriptable : ScriptableObject
{
    [Header("Name/ Description")]
    [SerializeField] private new string name = null;
    [TextArea(10, 100)]
    [SerializeField] private string description = null;


    public string Name => name;
    public string Description => description;
}
