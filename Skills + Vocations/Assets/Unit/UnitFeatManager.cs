using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Grape.EventManager;
using Grape.Constants;

[RequireComponent(typeof(Unit))]
public class UnitFeatManager : MonoBehaviour
{
    public Unit actorUnit;

    private void OnEnable()
    {
        EventManager.StartListening(Constants.Events.AddSkill, AddSkill);
        EventManager.StartListening(Constants.Events.TriggerSkill, OnInputRecieved);
        EventManager.StartListening(Constants.Events.RemoveSkill, RemoveSKill);
    }

    private void OnDisable()
    {
        EventManager.StopListening(Constants.Events.AddSkill, AddSkill);
        EventManager.StopListening(Constants.Events.TriggerSkill, OnInputRecieved);
        EventManager.StopListening(Constants.Events.RemoveSkill, RemoveSKill);
    }

    void Start()
    {
        AddSkill(this);
		if (actorUnit == null) return;
        foreach (BaseSkill feat in actorUnit.skills)
        {
            feat.Perform(actorUnit);
        }
    }

    public void AddSkill(object me)
	{
		if (actorUnit.primaryVocation == null)
		{
			return;
		}
		//playerSkills[0].AddSKill(this);
		foreach (BaseSkill feat in actorUnit.primaryVocation.vocationSkills)
        {
            feat.AddSKill(actorUnit);
        }
        foreach (BaseSkill feat in actorUnit.secondaryVocation.vocationSkills)
        {
            feat.AddSKill(actorUnit);
        }
    }

    public void StopPerforming()
	{
        actorUnit.skills[0].StopPerforming(actorUnit);
    }

    public void RemoveSKill(object player)
	{
        //Create a select skilll integer on the player, which changes based on what I select
        int selectedSkill = 0;
        Unit basePlayerUnit = (Unit)player;
        basePlayerUnit.skills[selectedSkill].Remove(basePlayerUnit);
    }

    void OnInputRecieved(object player)
	{
        Unit basePlayerUnit = (Unit)player;
        foreach(SkillInputs feat in basePlayerUnit.skills)
		{
            feat.OnInputRecived(basePlayerUnit);
		}
	}
}
