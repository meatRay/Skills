using System.Collections;
using Raspberry.ActorData.Runtime;
using System.Collections.Generic;
using Grape.Constants;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(VocationStatData))]
public class VocationEditor : Editor
{
	VocationStatData vocationGUI;

	SerializedObject soTarget;

	SerializedProperty Name;
	SerializedProperty description;
	SerializedProperty icon;

	SerializedProperty baseVitality;
	SerializedProperty basePower;
	SerializedProperty baseSpeed;
	SerializedProperty baseDefence;
	SerializedProperty baseResolve;
	SerializedProperty BST;

	SerializedProperty vitality;
	SerializedProperty power;
	SerializedProperty speed;
	SerializedProperty defence;
	SerializedProperty resolve;
	SerializedProperty TS;

	SerializedProperty skills;

	private void OnEnable()
	{
		vocationGUI = (VocationStatData)target;
		soTarget = new SerializedObject(target);

		Name = soTarget.FindProperty("name");
		description = soTarget.FindProperty("description");
		icon = soTarget.FindProperty("icon");

		baseVitality = soTarget.FindProperty("baseVitality");
		basePower = soTarget.FindProperty("basePower");
		baseSpeed = soTarget.FindProperty("baseSpeed");
		baseDefence = soTarget.FindProperty("baseDefence");
		baseResolve = soTarget.FindProperty("baseResolve");
		BST = soTarget.FindProperty("BST");

		vitality = soTarget.FindProperty("vitality");
		power = soTarget.FindProperty("power");
		speed = soTarget.FindProperty("speed");
		defence = soTarget.FindProperty("defence");
		resolve = soTarget.FindProperty("resolve");
		TS = soTarget.FindProperty("TS");

		skills = soTarget.FindProperty("vocationSkills");
	}
	public override void OnInspectorGUI()
	{
		soTarget.Update();

		EditorGUI.BeginChangeCheck();
		//base.OnInspectorGUI();
		vocationGUI.toolbarTab = GUILayout.Toolbar(vocationGUI.toolbarTab, new string[] { Constants.Editor.BasicUnitInfo, Constants.Editor.StatData, Constants.Editor.Skills});

		switch(vocationGUI.toolbarTab)
		{ 
			case 0:
				vocationGUI.currentTab = Constants.Editor.BasicUnitInfo;

				break;
			case 1:
				vocationGUI.currentTab = Constants.Editor.StatData;

				break;
			case 2:
				vocationGUI.currentTab = Constants.Editor.Skills;

				break;

		}

		if(EditorGUI.EndChangeCheck())
		{
			soTarget.ApplyModifiedProperties();
			GUI.FocusControl(null);
		}

		EditorGUI.BeginChangeCheck();

		switch (vocationGUI.currentTab)
		{ 
			case Constants.Editor.BasicUnitInfo:

				EditorGUILayout.PropertyField(Name);
				EditorGUILayout.PropertyField(description);
				EditorGUILayout.PropertyField(icon);
				break;

			case Constants.Editor.StatData:

				EditorGUILayout.PropertyField(baseVitality);
				EditorGUILayout.PropertyField(basePower);
				EditorGUILayout.PropertyField(baseSpeed);
				EditorGUILayout.PropertyField(baseDefence);
				EditorGUILayout.PropertyField(baseResolve);
				EditorGUILayout.PropertyField(BST);

				EditorGUILayout.PropertyField(vitality);
				EditorGUILayout.PropertyField(power);
				EditorGUILayout.PropertyField(speed);
				EditorGUILayout.PropertyField(defence);
				EditorGUILayout.PropertyField(resolve);
				EditorGUILayout.PropertyField(TS);

				if (GUILayout.Button("Calculate BST/TS"))
				{
					vocationGUI.CalculateBST();
				}
				break;

			case Constants.Editor.Skills:

				EditorGUILayout.PropertyField(skills);
				break;
		}

		if(EditorGUI.EndChangeCheck())
		{
			soTarget.ApplyModifiedProperties();
		}
	}
}
