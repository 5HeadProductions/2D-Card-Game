using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
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
    List<Unbreakable> factoryParent;

    private List<GameObject> factoryParentInstance = new List<GameObject>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            foreach (var factory in factoryParent)
            {
                var gameObject = GameObject.Instantiate(factory.objectToBeCarriedBetweenAllScenes, factory.positionOfObject, Quaternion.identity);
                factoryParentInstance.Add(gameObject);
                DontDestroyOnLoad(gameObject);
            }
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    //Its gonna need to be turned on by another game object
    void Update()
    {
        for(var i = 0; i < factoryParentInstance.Count; i++)
        {
            if (factoryParentInstance[i] != null && factoryParent[i].sceneObjectIsActiveIn == SceneManager.GetActiveScene().name)
            {
                factoryParentInstance[i].SetActive(true);
            }
            else
            {
                if (factoryParentInstance[i] != null)
                {
                    factoryParentInstance[i].SetActive(false);
                }
            }
        }
    }
}
