using System.Collections;   
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

/**
 * This Manager holds the function for playing audio oneshots
 * and also is the place where all audio lives and all other scripts
 * usually look for the sound here.
 * 
 * This component should be attached to the manager of the scene.
 */
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }

    public EventReference currencyGainSFX;
    public EventReference clickSFX;

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
    }

    public void PlayOneShot(EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }
}
