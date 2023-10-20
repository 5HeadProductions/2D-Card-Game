using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu]
public class Factory : ScriptableObject
{
    public int amountToIncrease;
    public float timeBetweenIncrease;
    public string factoryType;
}
