using Raspberry.ActorData.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Grape.Constants;
public class FetchCruve : MonoBehaviour
{

    public VocationStatData vocation;
    float targetCurveValue = 0f;
    public int actorLevel;
    public int maxLevel;
    //[Range(0F, 1F)]


    void Update()
    {
        float normalizedValue = Mathf.InverseLerp(1, maxLevel, actorLevel);
        var spdCurve = vocation.spdCurve;
        targetCurveValue = spdCurve.Evaluate(normalizedValue);
        if(Input.GetKeyDown(KeyCode.E))
		{
            Debug.Log($"{Constants.Attributes.SPD_SHORT}, {vocation.SpeedAtLevel(targetCurveValue)}");
        }

        if(Input.GetKeyDown(KeyCode.Q) && actorLevel != maxLevel)
		{
            actorLevel++;
		}
    }
}
