using System.Collections;
using System.Collections.Generic;
using ScriptableObjectMultiSelectDropdown;
using UnityEngine;
using UnityEditor;

public class BaseSkillData : ScriptableObject
{ 
	[Header("Basic Skill Info")]
	[SerializeField] public new string name = null;

	[TextArea]
	[SerializeField] public string description = null;

	[SerializeField] public Sprite sprite = null;
	[Header("Skill Data")]
	[SerializeField] private bool inputRequired = true;
	[SerializeField] public int levelNeeded = 0;


	[ScriptableObjectMultiSelectDropdown(typeof(VocationBaseData), grouping = ScriptableObjectGrouping.ByFolder)]
	public ScriptableObjectReference requiredVocation;

	public List<Tag> Tags;

	public string BaseName { get { return name; } }
	public string Description { get { return description; } }
	public Sprite Sprite { get { return sprite; } }
	public bool InputRequired { get { return inputRequired; } }
	public int LevelNeeded { get { return levelNeeded; } }

}
