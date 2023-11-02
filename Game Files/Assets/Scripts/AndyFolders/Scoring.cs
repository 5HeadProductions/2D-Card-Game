using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Define an enum-like structure using serialized fields
public enum Color
{
    Red,
    Orange,
    Yellow,
    Blue
}
public class Scoring : MonoBehaviour
{
    // Define an enum-like structure using serialized fields
    public Color boxColor = new Color();
    // This method will be called whenever a value is changed in the Inspector

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entered trigger");
        Debug.LogWarning("Triggered ->" + this.boxColor);

        switch(this.boxColor)
        {
            case Color.Blue:
                Debug.Log("Blue");
                break;
            case Color.Red:
                Debug.Log("Red");
                break;
            case Color.Yellow:
                Debug.Log("Yellow");
                break;
            case Color.Orange:
                Debug.Log("Orange");
                break;
        }
        if (other.CompareTag("Ball"))
            Destroy(other.gameObject);
    }
}
