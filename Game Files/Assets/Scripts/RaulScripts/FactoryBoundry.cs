using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryBoundry : MonoBehaviour
{
    private bool _clicked = false;
    private string _purchasedFactoryName;

    [SerializeField]
    [Tooltip("The factory to be activated when the plot is clicked.")]
    GameObject linkedFactory;

    [SerializeField]
    [Tooltip("The factory that has been purchased, the gameobject")]
    GameObject purchasedFactory;


    private void Start()
    {
        _purchasedFactoryName = purchasedFactory.name;
    }

    //When the purchased factory enters this(Factory plot collider) we turn the plot green to indicate the plot is available for a factory to be placed.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
    }

    //When the purchased factory exits this(Factory plot collider) we turn the plot white to indicate the plot is empty and available.
    private void OnTriggerExit2D(Collider2D collision)
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    //The function is entered while a collision is happening and we check if we have clicked the plot and it is the appropriate game object.
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(_clicked && collision.gameObject.name == _purchasedFactoryName + "(Clone)")
        {        
            _clicked = false;
            this.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
            this.gameObject.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(collision.gameObject);
        }
    }

    private void Update()
    {
        //Keeps the clicked bool depending on if the mouse is pressed.
        if (Input.GetMouseButton(0))
        {
            _clicked = true;
        }
        else
        {
            _clicked = false;
        }
    }
}
