using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/*
 * This script determines whether a purchasedFactory gameObject should be following
 * the mouse and/or should be loaded between scenes.
 * 
 * This script should be attached to purchasedFactory PreFab.
 */
public class PurchasedFactory : MonoBehaviour
{
    public bool isFollowingMouse = true;
    public bool loadBetweenScenes = false;

    void OnMouseDown()
    {
        //On click can be "picked up", starts following the mouse again.
        isFollowingMouse = true; 
    }

    void Update()
    {
        if (isFollowingMouse)
        {
            //Makes the gameObject follow the mouse.
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            mousePos.z = 0;
            this.gameObject.transform.position = mousePos;
        }

        if (loadBetweenScenes)
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
