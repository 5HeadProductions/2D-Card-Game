using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*
 * This class updates the currency whenever there is a change to the total currency.
 * 
 * This component should be attached to a text UI gameObject that will display the currency.
 */ 
public class CurrencyDisplay : MonoBehaviour
{
    private int oldTotal = 0;

    void Update()
    {
        if(oldTotal != CurrencyManager.instance.TotalCurrency)
        {
            this.gameObject.GetComponent<TextMeshProUGUI>().text = "Currrency: " + CurrencyManager.instance.TotalCurrency;
            oldTotal = CurrencyManager.instance.TotalCurrency;
        }
    }
}
