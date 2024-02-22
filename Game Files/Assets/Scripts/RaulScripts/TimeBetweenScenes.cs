using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeBetweenScenes : MonoBehaviour
{
    public static TimeBetweenScenes instance { get; private set; }

    public float timePassedInOtherScenes = 0;
    public float saver;
    public bool shouldSaveValue;
    private void Awake()
    {
        //Ensures that this component lives throughout scenes and destroys other gameobjects with this script attached.
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        SceneManager.activeSceneChanged += ChangeShouldSaveToTrue;
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name != "FactoryPurchasing")
        {
            timePassedInOtherScenes += 1 * Time.deltaTime;
        }
        
        if(shouldSaveValue)
        {
            saver = timePassedInOtherScenes;
            timePassedInOtherScenes = 0;
            shouldSaveValue = false;
        }
    }

    private void ChangeShouldSaveToTrue(Scene current, Scene next)
    {
        if (SceneManager.GetActiveScene().name == "FactoryPurchasing")
        {
           shouldSaveValue = true;
        }
    }
}
