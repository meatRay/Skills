using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DamageType
{
	Physical,
	Magical,
	True
}
public class HealthSystem
{
	public DamageType damageType;
	private int Hitpoints;
	private int TotalHitpoints;
	public HealthSystem(int TotalHitpoints)
	{
		Initalize(TotalHitpoints);
	}

	private void Initalize(int TotalHitpoints)
	{
		this.TotalHitpoints = TotalHitpoints;
		Hitpoints = TotalHitpoints;
	}

	public int GetHealth()
	{
		return Hitpoints;
	}

	public void TakeDamage(UnitStats curUnit ,UnitStats aggrssor,float damageAmount, DamageType damageType)
	{
		int damageTaken = Damage(curUnit, aggrssor, damageAmount, damageType);
		Hitpoints -= damageTaken;
		Hitpoints = Mathf.Clamp(Hitpoints, 0, int.MaxValue);
		Debug.Log(Hitpoints);
	}

	protected virtual int Damage(UnitStats curUnit ,UnitStats aggressor, float damageAmount, DamageType damageType)
	{
		switch(damageType)
		{
			case DamageType.Physical:
				return (int)Mathf.Clamp(damageAmount - curUnit.defence, 0, damageAmount);
			case DamageType.Magical:
				return (int)Mathf.Clamp(damageAmount - curUnit.resolve, 0, damageAmount);
			case DamageType.True:
				return (int)Mathf.Clamp(damageAmount, 0, damageAmount);
			default:
				Debug.Log("Damage Outside of DamageType Enum");
				return 0;
		}
	}
}
