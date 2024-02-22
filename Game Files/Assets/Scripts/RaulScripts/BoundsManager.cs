using FMOD;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEditor.Animations;
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

    private bool differentScene = false;
    // We would turn the boolean true when the scene name doesn't equal the one for the thing
    //We require the one that turns on all the components to use that one then it'll turn it off and wait for another scene switch

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
        if(SceneManager.GetActiveScene().name != "FactoryPurchasing")
        {
            differentScene = true;
        }
        for(var i = 0; i < factoryParentInstance.Count; i++)
        {
            if (factoryParentInstance[i] != null && factoryParent[i].sceneObjectIsActiveIn == SceneManager.GetActiveScene().name)
            {
                
                factoryParentInstance[i].SetActive(true);
                //Here we're gonna have to iterate through the children if it is a gemobject of type boundaries
                if (factoryParentInstance[i].gameObject.tag == "Bounds" && differentScene)
                {
                    int plotCount = 0;
                    for(int k = 0; k < factoryParentInstance[i].transform.childCount; k++)
                    {
                        if (factoryParentInstance[i].transform.GetChild(k).gameObject.tag == "FactoryPlots") plotCount++;
                    }
                    for (var j = 0; j < plotCount; j++)
                    {
                        factoryParentInstance[i].transform.GetChild(j).gameObject.GetComponent<FactoryBoundry>().startCoroutine = true;
                        if (factoryParentInstance[i].transform.GetChild(j).gameObject.GetComponent<FactoryBoundry>().hasPlacedFactory)
                        {
                            factoryParentInstance[i].transform.GetChild(j).gameObject.GetComponent<FactoryBoundry>().subtractTime = true;
                        }
                    }
                    differentScene = false;
                }
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
