using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillInputs : BaseSkill
{
	/// <summary>
	///	What should happen on recieving input.
	/// </summary>
	/// <param name="unit"> Unit component found.</param>
	public virtual void OnInputRecived(Unit unit)
	{

		//Unit PlayerUnit = (Unit)unitfeatManager;
		if (unit.skills.Contains(this) && InputRequired)
		{
			ReactionToInput(unit);
		}
	}
	/// <summary>
	///	What the skill will do on recieving an input.
	/// </summary>
	/// <param name="unit"> The unit that will react to the input.</param>
	public virtual void ReactionToInput(Unit unit)
	{
		//Unit curUnit = (Unit)unit;
		unit.m_Renderer.material.color = Color.white;
	}
}
