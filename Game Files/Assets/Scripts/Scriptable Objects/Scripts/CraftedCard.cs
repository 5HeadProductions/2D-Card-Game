using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Toolbars;
using UnityEngine;

[CreateAssetMenu]
public class CraftedCard : ScriptableObject
{
    public EventReference topLeftSound;
    public EventReference topRightSound;
    public EventReference bottomLeftSound;
    public EventReference bottomRightSound;

    public int currencyIncrease;
}

