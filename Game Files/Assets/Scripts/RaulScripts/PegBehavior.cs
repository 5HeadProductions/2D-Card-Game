using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegBehavior : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-collision.gameObject.transform.position.x, -collision.gameObject.transform.position.y), ForceMode2D.Impulse);
    }
}
