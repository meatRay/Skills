using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tags")]
public class Tag : ScriptableObject
{
	[SerializeField]private string tagName = null;
	[SerializeField]private string description = null;
	[SerializeField]private Sprite sprite = null;
	[SerializeField]private Color color = Color.white;

	public string TagName { get { return tagName; } }
	public string Description { get { return description; } }
	public Sprite Sprite { get { return sprite; } }
	public Color Color { get { return color; } }
}
