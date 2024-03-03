using FMOD;
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
    [Tooltip("Reference to the parent of all the factory boundaries.")]
    List<Unbreakable> unbreakables;

    private List<GameObject> unbreakableInstances = new List<GameObject>();
    private bool differentScene = false;
    
    private void Awake()
    {
        //Singleton carried across all scenes
        if (instance == null)
        {
            instance = this;
            //We instantiate each gameobject, add them to our list of known gameObjects and we make them undestroyable across scenes
            foreach (var factory in unbreakables)
            {
                var gameObject = GameObject.Instantiate(factory.objectToBeCarriedBetweenAllScenes, factory.positionOfObject, Quaternion.identity);
                unbreakableInstances.Add(gameObject);
                DontDestroyOnLoad(gameObject);
            }
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Update()
    {
        if(SceneManager.GetActiveScene().name != "FactoryPurchasing")
        {
            differentScene = true;
        }

        for(var i = 0; i < unbreakableInstances.Count; i++)
        {
            if (unbreakableInstances[i] != null && unbreakables[i].sceneObjectIsActiveIn == SceneManager.GetActiveScene().name)
            {
                //we set the gameobject to true if we are in the scene they are meant to be active
                unbreakableInstances[i].SetActive(true);
                
                //This is only donw for factory boundaries and when we come back into the factory placement (main) scene from another scene
                if (unbreakableInstances[i].gameObject.tag == "Bounds" && differentScene)
                {
                    //The gameObject is our factory boundaries and we are calculating how many plots we have.
                    int plotCount = 0;
                    for(int k = 0; k < unbreakableInstances[i].transform.childCount; k++)
                    {
                        if (unbreakableInstances[i].transform.GetChild(k).gameObject.tag == "FactoryPlots") plotCount++;
                    }

                    //For every plot we start their countdowns again and we subtract the time that has passed in another scene if they have a placed factory
                    for (var j = 0; j < plotCount; j++)
                    {
                        unbreakableInstances[i].transform.GetChild(j).gameObject.GetComponent<FactoryBoundry>().startCoroutine = true;
                        if (unbreakableInstances[i].transform.GetChild(j).gameObject.GetComponent<FactoryBoundry>().hasPlacedFactory)
                        {
                            unbreakableInstances[i].transform.GetChild(j).gameObject.GetComponent<FactoryBoundry>().subtractTime = true;
                        }
                    }
                    differentScene = false;
                }
            }
            else
            {
                //otherwise we set them as inactive
                if (unbreakableInstances[i] != null)
                {
                    unbreakableInstances[i].SetActive(false);
                }
            }
        }
    }
}
