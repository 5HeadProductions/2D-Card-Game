using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoad : MonoBehaviour
{
    private void Awake()
    {
        //Make it so there is one gameobject that is the MANAGER and it is a singleton
        if (SceneManager.GetActiveScene().name == "CardCrafting")
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
