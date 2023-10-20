using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryGrowth : MonoBehaviour
{
    [SerializeField]
    Factory factoryScriptableObject;

    private float timeSinceLastIncrease;
    private int amountProduced = 0;


    private void Update()
    {
        timeSinceLastIncrease += Time.deltaTime;

        if (timeSinceLastIncrease >= factoryScriptableObject.timeBetweenIncrease) 
        {
            amountProduced += factoryScriptableObject.amountToIncrease;
            timeSinceLastIncrease = 0.0f;
        }

    }
}

