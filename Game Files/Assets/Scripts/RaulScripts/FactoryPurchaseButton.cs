using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryPurchaseButton : MonoBehaviour
{
    private GameObject factoryInstance;

    [SerializeField]
    GameObject factoryGameObject;
    [SerializeField]
    [Tooltip("Cost of the factory.")]
    private int cost;
    
    //Function is meant to be called with a button press, Instantiates a draggable factory.
    public void PurchaseFactory()
    {
        if(cost <= CurrencyManager.instance.TotalCurrency)
        {
            factoryInstance = GameObject.Instantiate(factoryGameObject);
            CurrencyManager.instance.TotalCurrency -= cost;
        }
    }
}
