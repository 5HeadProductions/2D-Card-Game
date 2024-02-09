using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * This component ensures the specified gameobject lives throughout all scenes
 * and also ensures that any other gameobject with this component attached is destroyed.
 * This component also deactivates the gameobject if it is active in the incorrect scene.
 * 
 * This component should be attached to the manager of the scene.
 */
public class BoundsManager : MonoBehaviour
{
    public static BoundsManager instance { get; private set; }
    [SerializeField]
    [Tooltip("Name of the scene this object should be active in.")]
    string sceneObjectIsActiveIn;

    [SerializeField]
    [Tooltip("Reference to the parent of all the factory boundaries.")]
    GameObject factoryParent;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(factoryParent);
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
            Destroy(factoryParent);
        }
    }
    //Its gonna need to be turned on by another game object
    void Update()
    {

        if(sceneObjectIsActiveIn == SceneManager.GetActiveScene().name)
        {
            factoryParent.gameObject.SetActive(true);
        }
        else
        {
            factoryParent.gameObject.SetActive(false);
        }
    }
}
