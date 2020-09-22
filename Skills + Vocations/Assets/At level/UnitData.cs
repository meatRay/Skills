using Kryz.CharacterStats;
using Raspberry.ActorData.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitData : MonoBehaviour
{
    [Header("Units Base Stats")]
    public CharacterStat Vitality;
    public CharacterStat Power;
    public CharacterStat Speed;
    public CharacterStat Defence;
	public CharacterStat Resolve;
    [Header("Units Stats")]
    public float vitality;
    public float power;
    public float speed;
    public float defence;
    public float resolve;
    [Header("Actors Level Data")]
    public int actorLevel;
    public int maxLevel;
    [Header("Actors Vocation")]
    public VocationStatData primaryVocation;
    public VocationStatData secondaryVocation;
    [Header("Skills/Passives")]
    public List<BaseSkill> skills;
    [Header("Renderer")]
    public Renderer m_Renderer;

}
