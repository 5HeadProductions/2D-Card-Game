using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryBoundry : MonoBehaviour
{
    //Check the tag on it to verify it is indeed a purchased factory
    //Have update running and have a boolean that is updated by mouse click
    //On trigger we check the tag and that we have clicked
    bool clicked = false;

    [SerializeField]
    [Tooltip("The factory to be activated when the plot is clicked.")]
    GameObject linkedFactory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.name);
        if(clicked && collision.gameObject.name == "PurchasedFactory(Clone)")
        {
            
            clicked = false;
            this.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //Debug.Log("Entered Input");
            clicked = true;
        }
        else
        {
            clicked = false;
        }
    }
}
