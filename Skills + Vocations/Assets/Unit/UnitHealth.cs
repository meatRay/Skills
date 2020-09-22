using Kryz.CharacterStats;
using Raspberry.ActorData.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Unit))]
public class UnitHealth : MonoBehaviour
{
    public Unit unit;
	private HealthSystem healthSystem;
    // Start is called before the first frame update
    void Start()
    {
        healthSystem = new HealthSystem((int)unit.Vitality.Value);
        Debug.Log(healthSystem.GetHealth());
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.R))
        {
            healthSystem.TakeDamage(unit, unit, 100, unit.damageType);
        }
        */
    }
}
