using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script checks if the player has enough currency to purchase a factory.
 * 
 * This component should be attached to the button that will purchase the factory.
 */
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
