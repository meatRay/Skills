using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISkillInputs
{
	void OnInputRecived(Unit unit);
	void Perform(Unit unit);
	void ReactionToInput(Unit unit);
	void StopPerforming(Unit unit);
}
