using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

/*
 * This is a singleton that takes charge of adding cards to the possible cards
 * that can be spawned when crafting cards and can increase the chances of the cards
 * spawning.
 * 
 * This script should be attached to the manger of the scene usually an empty gameObject.
 */
public class CardPool : MonoBehaviour
{
    
    [Header("Card List")]
    public GameObject bronzeCard;
    public GameObject silverCard;


    public static List<GameObject> cardsObjects = new List<GameObject>();
    public static List<int> chanceArray = new List<int>();
    public static CardPool instance { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        //Initiate the card pool if it has not been initiated yet.
        if (!cardsObjects.Contains(bronzeCard))
        {
            AddGameObject(bronzeCard, 10);
        }
    }

    /*
     * Adds a new card gameObject to the pool and adds the specified chance for the card to be drawn.
     */
    public void AddGameObject(GameObject cardObject, int drawChance)
    {
        cardsObjects.Add(cardObject);
        for (int i = 0; i < drawChance; i++)
        {
            chanceArray.Add(cardsObjects.Count - 1);
        }
    }

    /*
     * Finds the index of the card and increases chances of drawing by specified amount.
     */
    public void IncreaseChance(GameObject cardObject, int drawChance)
    {
        int index = cardsObjects.IndexOf(cardObject);
        for (int i = 0; i < drawChance; i++)
        {
            chanceArray.Add(index);
        }
    }

    /*
     * Based on the current chances chooses randomly a number on the chanceArray
     * then we store the value at that index in the chance array and use that value as the 
     * index for the cardsObject array.
     */
    public GameObject DrawCard()
    {
        int index = chanceArray[UnityEngine.Random.Range(0, chanceArray.Count)];
        return cardsObjects[index];
    }

    /*
     * Given a gameObject this function extractes the CraftedCard 
     * scriptable object from it provided it has a CardInfo component.
     */
    public CraftedCard GetCardInfo(GameObject gameObject)
    {
        return gameObject.GetComponent<CardInfo>().cardInfo;
    }
}
