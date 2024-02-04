using UnityEngine;
using TMPro;
using System.Collections;
using FMODUnity;
using UnityEngine.SceneManagement;

/*
 * This class is a manager in charge of detecting if we are 
 * in the card crafting Scene and counting the amount of clicks
 * as well as incrementing the currency when clicks reach the clickThreshold.
 * This Class also updates the animator parameters to assist the animations
 * and also updates the currency text.
 */
public class ClickCounter : MonoBehaviour
{
    private int clickCount = 0;
    private bool canClick = true;

    [SerializeField]
    CraftedCard cardInfo;

    [SerializeField]
    [Tooltip("Reference to the animator of the card pieces coming together.")]
    private Animator animator;
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
    [Tooltip("The name of the scene the card crafting is happening, this variable is used to determine whether we count or ignore the clicks")]
    private string cardCraftingSceneName; 

    private void Update()
    {
        //Checks if the mouse click and if we allow the click to happen
        if (Input.GetMouseButtonDown(0) && canClick)
        {
            //Check if we are in the card crafting scene or else do not increment clicks or play any more logic
            if (SceneManager.GetActiveScene().name == cardCraftingSceneName)
            {
                clickCount++;

                //Sets the card animation into play depending on which click it is
                if (clickCount % 4 == 1)
                {
                    animator.SetBool("emptyToTl", true);
                    AudioManager.instance.PlayOneShot(cardInfo.topLeft, this.transform.position);
                }
                else if (clickCount % 4 == 2)
                {
                    animator.SetBool("tlToTr", true);
                    AudioManager.instance.PlayOneShot(cardInfo.topRight, this.transform.position);
                }
                else if (clickCount % 4 == 3)
                {
                    animator.SetBool("trToBl", true);
                    AudioManager.instance.PlayOneShot(cardInfo.bottomLeft, this.transform.position);
                }
                else if (clickCount % 4 == 0)
                {
                    canClick = false;
                    animator.SetBool("blToBr", true);
                    animator.SetBool("Completed", true);

                    StartCoroutine(InstantiateAfterDelayCoroutine());
                    GameObject.Destroy(animator.gameObject, 1f);
                    AudioManager.instance.PlayOneShot(cardInfo.bottomRight, this.transform.position);
                    GameObject.Find("CurrencyManager").GetComponent<CurrencyManager>().TotalCurrency += cardInfo.currencyIncrease;
                }


                // Check if the click count reaches the threshold
                if (clickCount >= clickThreshold)
                {
                    // Reset the click count and increase the players currency
                    clickCount = 0;
                }
            }
            // Update the Text components with the total counts
            if (clickCountText != null)
            {
                clickCountText.text = "Clicks: " + clickCount;
            }
            
        }
    }

    //Instantiates a new game object for the animator after a alloted amount of time
    IEnumerator InstantiateAfterDelayCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        GameObject craftedCard = GameObject.Instantiate(CardPool.instance.drawCard());
        animator = craftedCard.GetComponent<Animator>();
        cardInfo = CardPool.instance.GetCardInfo(craftedCard);
        canClick = true;
    }
}
