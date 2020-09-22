using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnitLevelManager : MonoBehaviour
{
    public UnityEvent IncrementLevel = new UnityEvent();
	void Update()
    {
       IncreaseActorLevel();
    }
    public void IncreaseActorLevel()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            IncrementLevel?.Invoke();
        }
    }

}
