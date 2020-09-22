using Raspberry.ActorData.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStats : UnitData
{

    //float targetCurveValue = 0f;
    public void IncrementLevel()
	{
        if (!(actorLevel != maxLevel)) return;
        actorLevel++;
	}
	public void VocationUpdate()
	{
		if (primaryVocation != null)
		{
            VocationStats(primaryVocation);
        }

		if (secondaryVocation != null)
		{
			VocationStats(secondaryVocation);
		}
		UpdateBaseStat();
        UpdateStats();
    }

    private void VocationStats(VocationStatData actorVocationData)
    {
        //targetCurveValue = primaryVocation.defCurve.Evaluate(normalizedValue);
        float normalizedValue = Mathf.InverseLerp(0, maxLevel, actorLevel);
        actorVocationData.RemoveLevelStat(this);
        actorVocationData.FetchCurrentStat(this, normalizedValue);
    }

    private void UpdateBaseStat()
    {
        //find the average between primary vocation stat and secondary vocation stat
        Vitality.BaseValue = (primaryVocation.baseVitality + secondaryVocation.baseVitality)/2;
        Power.BaseValue = (primaryVocation.basePower + secondaryVocation.basePower)/2;
        Speed.BaseValue = (primaryVocation.baseSpeed + secondaryVocation.baseSpeed)/2;
        Defence.BaseValue = (primaryVocation.baseDefence + secondaryVocation.baseDefence)/2;
        Resolve.BaseValue = (primaryVocation.baseResolve + secondaryVocation.baseResolve)/2;
    }

   
    private void UpdateStats()
    {
        vitality = Vitality.Value;
        power = Power.Value;
        speed = Speed.Value;
        defence = Defence.Value;
        resolve = Resolve.Value;
    }
}
