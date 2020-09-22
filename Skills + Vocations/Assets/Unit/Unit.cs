using Raspberry.ActorData.Runtime;
using Kryz.CharacterStats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : UnitStats
{
    //HealthSystem healthSystem;
    //public DamageType damageType;
    // Start is called before the first frame update
    void Awake()
    {
        VocationUpdate();     
    }
}
