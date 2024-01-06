using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    private int _totalCurrency = 0;
    public int TotalCurrency
    {
        get { return _totalCurrency; }
        set { _totalCurrency = value; } //value = prev total + increment
    }
}
