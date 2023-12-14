using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPool : MonoBehaviour
{
    public List<GameObject> cardsObjects;
    List<int> chanceArray;
    GameObject startingCard;

    private void Start()
    {
        cardsObjects.Add(startingCard);
    }

    public void AddGameObject(GameObject cardObject, int drawChance)
    {
        this.cardsObjects.Add(cardObject);
        for (int i = 0; i < drawChance; i++)
        {
            this.chanceArray.Add(this.cardsObjects.Count - 1);
        }
    }

    public void IncreaseChance(GameObject cardObject, int drawChance)
    {
        for (int i = 0; i < drawChance; i++)
        {
            this.chanceArray.Add(cardsObjects.IndexOf(cardObject));
        }
    }
}
