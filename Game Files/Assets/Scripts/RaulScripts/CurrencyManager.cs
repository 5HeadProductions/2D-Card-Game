using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class is a singleton manager that keeps track of the players current currency.
 * 
 * This component should be attached to an empty gameobject. There should NOT be more than one in a scene.
 */
public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager instance { get; private set; }

    
    private static int _totalCurrency;
    public int TotalCurrency
    {
        get { return _totalCurrency; }
        set { _totalCurrency = value; } //value = prev total + increment
    }
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Currency Manager in the scene");
        }
        instance = this;
    }

}
