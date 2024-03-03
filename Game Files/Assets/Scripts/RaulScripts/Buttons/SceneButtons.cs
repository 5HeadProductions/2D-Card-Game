using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * This class loads is the functions the buttons will call provided they are given a name.
 * (SHOULD refactor to only one function called load scene that accepts a scene name there is no reason these are seperate)
 */
public class SceneButtons : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Name of the scene with factory boundries.")]
    string factorySceneName;

    [SerializeField]
    [Tooltip("Name of the scene with combining the card pieces together.")]
    string cardCraftingSceneName;

    [SerializeField]
    [Tooltip("Name of the scene where you can buy factories and cards.")]
    string purchaseMenuSceneName;


    public void NavigateToFactoryScene()
    {
        AudioManager.instance.PlayOneShot(AudioManager.instance.clickSFX, this.transform.position);
        SceneManager.LoadScene(factorySceneName);
    }

    public void NavigateToCardCraftingScene()
    {
        AudioManager.instance.PlayOneShot(AudioManager.instance.clickSFX, this.transform.position);
        SceneManager.LoadScene(cardCraftingSceneName);
    }

    public void purchaseMenuScene()
    {
        AudioManager.instance.PlayOneShot(AudioManager.instance.clickSFX, this.transform.position);

        SceneManager.LoadScene(purchaseMenuSceneName);
    }
}
