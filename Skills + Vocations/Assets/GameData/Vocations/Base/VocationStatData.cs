using Kryz.CharacterStats;
using System.Collections.Generic;
using UnityEngine;


namespace Raspberry.ActorData.Runtime
{
    public class VocationStatData : VocationBaseData
    {
        [Header("Stat curve")]
        public AnimationCurve vitCurve = AnimationCurve.Linear(0, 0, 1, 1);
        public AnimationCurve pwrCurve = AnimationCurve.Linear(0, 0, 1, 1);
        public AnimationCurve spdCurve = AnimationCurve.Linear(0, 0, 1, 1);
        public AnimationCurve defCurve = AnimationCurve.Linear(0, 0, 1, 1);
        public AnimationCurve resCurve = AnimationCurve.Linear(0, 0, 1, 1);


        public AnimationCurve FetchCurve(ActorAttributeType type)
        {
			switch (type)
			{
                case ActorAttributeType.Vitality:
                    return vitCurve;
                case ActorAttributeType.Power:
                    return pwrCurve;
                case ActorAttributeType.Speed:
                    return spdCurve;
                case ActorAttributeType.Defence:
                    return defCurve;
                default:
                    return resCurve;       
            }
        }

        public int VitalityAtLevel(float targetCurveValue)
        {
            return Mathf.RoundToInt(Mathf.Lerp(0, vitality, targetCurveValue));
        }
        
        public int PowerAtLevel(float targetCurveValue)
        {
            return Mathf.RoundToInt(Mathf.Lerp(0, power, targetCurveValue));
        }
        
        public int SpeedAtLevel(float targetCurveValue)
        {
            return Mathf.RoundToInt(Mathf.Lerp(0, speed, targetCurveValue));
        }
        
        public int DefenceAtLevel(float targetCurveValue)
		{
            return Mathf.RoundToInt(Mathf.Lerp(0, defence, targetCurveValue));
		}

        public int ResolveAtLevel(float targetCurveValue)
        {
            return Mathf.RoundToInt(Mathf.Lerp(0, resolve, targetCurveValue));
        }
    
        public void FetchCurrentStat(UnitStats unit, float normalizedValue)
		{
            float vitCurveValue = vitCurve.Evaluate(normalizedValue);
            if (VitalityAtLevel(vitCurveValue) != 0)               
                unit.Vitality.AddModifier(new StatModifier(VitalityAtLevel(vitCurveValue), StatModType.Flat, this));

            //Debug.Log($"{Constants.Attributes.VIT_SHORT}, {VitalityAtLevel(targetCurveValue)}");

            float pwrCurveValue = pwrCurve.Evaluate(normalizedValue);
            if (PowerAtLevel(pwrCurveValue) != 0)
                unit.Power.AddModifier(new StatModifier(PowerAtLevel(pwrCurveValue), StatModType.Flat, this));

            //Debug.Log($"{Constants.Attributes.PWR_SHORT}, {PowerAtLevel(targetCurveValue)}");

            float spdCurveValue = spdCurve.Evaluate(normalizedValue);
            if (SpeedAtLevel(spdCurveValue) != 0)
                unit.Speed.AddModifier(new StatModifier(SpeedAtLevel(spdCurveValue), StatModType.Flat, this));

            //Debug.Log($"{Constants.Attributes.SPD_SHORT}, {SpeedAtLevel(targetCurveValue)}");
            float defCurveValue = defCurve.Evaluate(normalizedValue);
            if (DefenceAtLevel(defCurveValue) != 0)
                unit.Defence.AddModifier(new StatModifier(DefenceAtLevel(defCurveValue), StatModType.Flat, this));

            //Debug.Log($"{Constants.Attributes.DEF_SHORT}, {DefenceAtLevel(targetCurveValue)}");

            float resCurveValue = resCurve.Evaluate(normalizedValue);
            if (ResolveAtLevel(resCurveValue) != 0)
                unit.Resolve.AddModifier(new StatModifier(ResolveAtLevel(resCurveValue), StatModType.Flat, this));
            
            //Debug.Log($"{Constants.Attributes.RES_SHORT}, {ResolveAtLevel(targetCurveValue)}");
        }

        public void RemoveLevelStat(UnitStats unit)
        {
            unit.Vitality.RemoveAllModifiersFromSource(this);
            unit.Power.RemoveAllModifiersFromSource(this);
            unit.Speed.RemoveAllModifiersFromSource(this);
            unit.Defence.RemoveAllModifiersFromSource(this);
            unit.Resolve.RemoveAllModifiersFromSource(this);

        }
    }
}