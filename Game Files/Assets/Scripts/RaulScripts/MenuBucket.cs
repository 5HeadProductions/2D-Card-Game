using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script will make the purchased factories stop following the mouse
 * and will give the purchased factory the ability to load between scenes.
 * 
 * This component should be attached to the gameObject that will carry 
 * purchased factories between scenes.
 */
public class MenuBucket : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<PurchasedFactory>().isFollowingMouse = false;
        collision.gameObject.GetComponent<PurchasedFactory>().loadBetweenScenes = true;
    }
}
