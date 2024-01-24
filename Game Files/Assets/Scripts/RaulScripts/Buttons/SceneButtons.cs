using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene(factorySceneName);
    }

    public void NavigateToCardCraftingScene()
    {
        SceneManager.LoadScene(cardCraftingSceneName);
    }

    public void purchaseMenuScene()
    {
        SceneManager.LoadScene(purchaseMenuSceneName);
    }
}
