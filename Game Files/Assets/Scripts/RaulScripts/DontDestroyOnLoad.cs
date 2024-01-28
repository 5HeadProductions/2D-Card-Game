using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * This class will keep the gameObject from being deleted inbetween scenes.
 * 
 * This component should be attached to any gameObject you don't want destroyed between scenes.
 */
public class DontDestroyOnLoad : MonoBehaviour
{
    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "CardCrafting")
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
