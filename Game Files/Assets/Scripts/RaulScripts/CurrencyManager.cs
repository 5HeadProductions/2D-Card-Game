using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager instance { get; private set; }

    
    private int _totalCurrency = 0;
    public int TotalCurrency
    {
        get { return _totalCurrency; }
        set { _totalCurrency = value; } //value = prev total + increment
    }
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Audio Manager in the scene");
        }
        instance = this;
    }

}
