using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBucket : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.transform.SetParent(transform);
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
    }
}
