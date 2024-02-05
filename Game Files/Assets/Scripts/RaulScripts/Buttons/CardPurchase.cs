using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

/*
 * This script offers a function to purchase a card with the currencyManager totalCurrency
 * and adds the purchased card to the current CardPool.
 * 
 * This component should be attached to the button that will grant the user a new card.
 */
public class CardPurchase : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The gameObject to be added to the CardPool.")]
    private GameObject _cardToBePurchased;
    [SerializeField]
    [Tooltip("Adds specified amount of entries to the chance array in CardPool.")]
    private int _drawChance;
    [SerializeField]
    [Tooltip("The amount totalCurrency in CurrencyManger will be subrated by or checked for.")]
    private int _cardCost;

    /*
     * This function adds the card to the possible cards to be drawn when crafting cards
     * and sends an error message when the player doesn't have enough currency.
     */
    public void PurchaseCard()
    {
        if(CurrencyManager.instance.TotalCurrency >= _cardCost)
        {   
            CardPool.instance.AddGameObject(_cardToBePurchased, _drawChance);
            CurrencyManager.instance.TotalCurrency -= _cardCost;
        }
        else
        {
            //Replace with a future pop up 
            Debug.Log("NOT ENOUGH FUNDS");
        }
    }
}
