using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * This script is in charge of detecting when purchased factories are near the
 * available plots of land. This script also detects when an available plot of land 
 * is clicked and places a factory when this event happens.
 * 
 * This component should be attached to the boundries of where factories can be placed.
 */
public class FactoryBoundry : MonoBehaviour
{
    public bool hasPlacedFactory = false;
    public bool startCoroutine;
    public bool subtractTime;

    private bool _clicked = false;
    private string _purchasedFactoryName;
    private bool canEnterPlinko = false;
    private bool _clickedOnFactory = false;
    private float timeBeforeAllowPlinko;

    [SerializeField]
    [Tooltip("The text component that will display the time before the player can access plinko.")]
    TextMeshProUGUI plinkoTimerDisplay;

    [SerializeField]
    [Tooltip("How much currency the player should receive for having the factory placed.")]
    int increaseRate;

    [SerializeField]
    [Tooltip("Time in seconds that should pass before we give the player more currency for the factory.")]
    int timeBetweenGain;

    [SerializeField]
    [Tooltip("How much time the player should wait each time they play plinko before they can play again")]
    int plinkoAccessTime = 20;

    [SerializeField]
    [Tooltip("The factory to be activated when the plot is clicked.")]
    GameObject linkedFactory;

    [SerializeField]
    [Tooltip("The factory that has been purchased, the gameobject")]
    GameObject purchasedFactory;

    private void Start()
    {
        _purchasedFactoryName = purchasedFactory.name;

        StartCoroutine(IncreaseVariableCoroutine());
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
        if (_clicked && collision.gameObject.name == _purchasedFactoryName + "(Clone)")
        {
            _clicked = false;
            StartCoroutine(AllowFactoryToBePlacedAfterDelayCoroutine());
            this.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
            this.gameObject.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(collision.gameObject);
            canEnterPlinko = true;
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

        if (Input.GetMouseButtonDown(0))
        {
            var clickTime = DateTime.Now;
            var mousePosition = Input.mousePosition;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit != null && hit.collider != null)
            {
                if (hit.collider.gameObject == this.gameObject && hasPlacedFactory)
                {
                    Debug.Log(this.gameObject.name);
                    _clickedOnFactory = true;
                }
            }
            else
            {
                _clickedOnFactory = false;
            }

        }

        if (hasPlacedFactory && _clicked && _clickedOnFactory && canEnterPlinko)
        {
            _clickedOnFactory = false;
            canEnterPlinko = false;
            SceneManager.LoadScene("Plinko");
        }

        if (startCoroutine)
        {
            StartCoroutine(IncreaseVariableCoroutine());
            startCoroutine = false;
        }

        if (subtractTime)
        {
            timeBeforeAllowPlinko = subtractTimeFromBeingInOtherScenes(TimeBetweenScenes.instance.saver);
            subtractTime = false;
        }

        if (!canEnterPlinko &&  hasPlacedFactory)
        {
            timeBeforeAllowPlinko -= 1 * Time.deltaTime;
        }

        if(timeBeforeAllowPlinko <= 0)
        {
            canEnterPlinko = true;
            timeBeforeAllowPlinko = plinkoAccessTime;
        }

        plinkoTimerDisplay.text = timeBeforeAllowPlinko.ToString();
    }

    private float subtractTimeFromBeingInOtherScenes(float time)
    {
        var newTime = timeBeforeAllowPlinko - time;
        if(canEnterPlinko)
        {
            return plinkoAccessTime;
        }
        if (newTime <= 0)
        {
            canEnterPlinko = true;
            return plinkoAccessTime;
        }
        else
        {
            return newTime;
        }
    }


    //Coroutine enforces a half second delay to avoid the bug of creating a new factory and getting taken to the Plinko scene immediately.
    IEnumerator AllowFactoryToBePlacedAfterDelayCoroutine()
    {
        yield return new WaitForSeconds(1f);
        hasPlacedFactory = true;
    }

    //Waits the timeBetweenGain in seconds before giving the player currency and verifys the player has a factory first
    private IEnumerator IncreaseVariableCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenGain);

            if (hasPlacedFactory)
            {
                CurrencyManager.instance.TotalCurrency += increaseRate;
            }
        }
    }
}
