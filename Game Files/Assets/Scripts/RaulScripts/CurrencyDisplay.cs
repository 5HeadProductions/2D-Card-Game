using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencyDisplay : MonoBehaviour
{
    private int oldTotal = 0;

    // Update is called once per frame
    void Update()
    {
        if(oldTotal != CurrencyManager.instance.TotalCurrency)
        {
            this.gameObject.GetComponent<TextMeshProUGUI>().text = "Currrency: " + CurrencyManager.instance.TotalCurrency;
            oldTotal = CurrencyManager.instance.TotalCurrency;
        }
    }
}
