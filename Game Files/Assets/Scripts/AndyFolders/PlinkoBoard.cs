using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlinkoBoard : MonoBehaviour
{
    private string currTag;
    [SerializeField] private int pointsToAdd;
    [SerializeField] private float bounceForce;

    // Start is called before the first frame update
    void Start()
    {
        currTag =this.gameObject.tag;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Entered trigger");
        if(other.gameObject.CompareTag("Ball"))
        {
            Debug.Log("Hit ball");
            // Apply upward force to make the ball bounce
            if (gameObject.CompareTag("Obstacle"))
            {
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
                Debug.Log("FORCE");
            }
            if (currTag == "Box")
            {
                other.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            }
        }
    }
}
