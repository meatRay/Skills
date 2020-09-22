	using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skill/Input/Color")]
public class ColorChangeSkill : SkillInputs, ISkillInputs
{
	[Header("Color change info")]
	public Color color;
	public Color startColor;

	public override void OnInputRecived(Unit unit)
	{
		//Unit PlayerUnit = (Unit)unitfeatManager;
		if ((!CheckRequirements(unit, requiredVocation))) return;
		if (unit.skills.Contains(this) && InputRequired)
		{
			ReactionToInput(unit);
		}
	}

	public override void Perform(Unit unit)
	{
		if(CheckRequirements(unit, requiredVocation))
		{
			Debug.Log("You have met the requirements.");
			base.Perform(unit);
			unit.m_Renderer.material.color = startColor;
			TellMeTags();
		}
		else
		{
			Debug.Log("You have not met the requirements.");
		}
	}

	public void TellMeTags()
	{
		if (Tags.Count == 0) return;

		foreach (Tag tag in Tags)
		{
			Debug.Log($"{name}, {tag.name}");
		}

	}

	public override void ReactionToInput(Unit unit)
	{
		//Unit basePlayerUnit = (Unit)playerUnit;
		unit.m_Renderer.material.color = color;
	}

	public override void StopPerforming(Unit playerUnit)
	{
		playerUnit.m_Renderer.material.color = Color.white;
	}
}
