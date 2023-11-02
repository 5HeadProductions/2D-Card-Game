using UnityEngine;
using TMPro;

public class ClickCounter : MonoBehaviour
{
    private int clickCount = 0;
    [SerializeField]
    private Animator animator; // Reference to the Animator component for playing animations
    [SerializeField]
    public int clickThreshold = 4; // Number of clicks required to play the animation
    [SerializeField]
    public TextMeshProUGUI clickCountText; // Reference to the TextMeshPro Text component

    private void Start()
    {
        // Play the animation
        if (animator != null)
        {
            animator.SetBool("Start", true); // "PlayAnimation" is the trigger parameter in the Animator controller
        }
    }
    private void Update()
    {
        // Check for left mouse button click
        if (Input.GetMouseButtonDown(0))
        {
            // Increment the click count and total count
            clickCount++;
            CounterManager.Instance.TotalCounter++;
            // Update the TextMeshPro Text component with the total count
            if (clickCountText != null)
            {
                clickCountText.text = "Clicks: " + CounterManager.Instance.TotalCounter;
            }

            // Check if the click count reaches the threshold
            if (clickCount >= clickThreshold)
            {
                animator.SetBool("Start", false); // "PlayAnimation" is the trigger parameter in the Animator controller
                animator.SetBool("End", true); // "PlayAnimation" is the trigger parameter in the Animator controller

                // Reset the click count
                clickCount = 0;
            }
            else
            {
                animator.SetBool("Start", true);
                animator.SetBool("End", false);
            }
        }
    }
}
