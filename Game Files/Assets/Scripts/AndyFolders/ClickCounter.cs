using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System.Collections;

public class ClickCounter : MonoBehaviour
{
    private int clickCount = 0;
    private bool canClick = true;

    [SerializeField]
    private Animator animator; // Reference to the Animator component for playing animations
    [SerializeField]
    [Tooltip("Number of clicks required to gain money from the card completing.")]
    public int clickThreshold = 4;
    [SerializeField]
    [Tooltip("Component displaying clicks (to be deleted for actual game).")]
    public TextMeshProUGUI clickCountText;
    [SerializeField]
    [Tooltip("Component displaying the currency")]
    public TextMeshProUGUI currencyCountText;
    [SerializeField]
    [Tooltip("Component that contains the cards coming up")]
    public CardPool cardPool;

    private void Update()
    {
        //Checks if the mouse click and if we allow the click to happen
        if (Input.GetMouseButtonDown(0) && canClick)
        {
            clickCount++;
            CounterManager.Instance.TotalCounter++;

            // Update the Text components with the total counts
            if (clickCountText != null)
            {
                clickCountText.text = "Clicks: " + CounterManager.Instance.TotalCounter;
            }
            if (currencyCountText != null)
            {
                currencyCountText.text = "Currrency: " + GameObject.Find("CurrencyManager").GetComponent<CurrencyManager>().TotalCurrency;
            }

            //Sets the card animation into play depending on which click it is
            if (clickCount % 4 == 1)
            {
                animator.SetBool("emptyToTl", true);
            }
            else if (clickCount % 4 == 2)
            {
                animator.SetBool("tlToTr", true);
            }
            else if (clickCount % 4 == 3)
            {
                animator.SetBool("trToBl", true);
            }
            else if (clickCount % 4 == 0)
            {
                canClick = false;
                animator.SetBool("blToBr", true);
                animator.SetBool("Completed", true);

                StartCoroutine(InstantiateAfterDelayCoroutine());
                GameObject.Destroy(animator.gameObject, 1f);
            }


            // Check if the click count reaches the threshold
            if (clickCount >= clickThreshold)
            {
                // Reset the click count and increase the players currency
                clickCount = 0;

                GameObject.Find("CurrencyManager").GetComponent<CurrencyManager>().TotalCurrency++;

            }
        }
    }

    //Instantiates a new game object for the animator after a alloted amount of time
    IEnumerator InstantiateAfterDelayCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        GameObject gameObject = GameObject.Instantiate(cardPool.startingCard);
        animator = gameObject.GetComponent<Animator>();
        canClick = true;
    }
}
