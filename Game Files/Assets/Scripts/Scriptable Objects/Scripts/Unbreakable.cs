using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Unbreakable : ScriptableObject
{
    public GameObject objectToBeCarriedBetweenAllScenes;
    public string sceneObjectIsActiveIn;
    public Vector3 positionOfObject;
}
