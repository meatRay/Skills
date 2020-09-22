using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VocationBaseData : BaseDataScriptable
{
    [HideInInspector]
    public int toolbarTab;
    public string currentTab;

    public Sprite icon;

    [Header("Base Stats")]
    public int baseVitality;
    public int basePower;
    public int baseSpeed;
    public int baseDefence;
    public int baseResolve;
    public int BST = 0;

    [Header("Level Stats")]
    public int vitality;
    public int power;
    public int speed;
    public int defence;
    public int resolve;
    public int TS = 0;

    public List<BaseSkill> vocationSkills = new List<BaseSkill>();

    //[ContextMenu("Click me!?")]
    public void CalculateBST()
	{
        BST = baseDefence + basePower + baseSpeed + baseVitality + baseResolve;
        TS = vitality + power + speed + defence + resolve;
    }
}
