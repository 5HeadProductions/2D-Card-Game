using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CraftedCard : ScriptableObject
{
    public EventReference topLeft;
    public EventReference topRight;
    public EventReference bottomLeft;
    public EventReference bottomRight;

    public int currencyIncrease;
}

