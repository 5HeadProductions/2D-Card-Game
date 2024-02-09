using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
