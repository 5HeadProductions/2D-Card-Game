using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PurchasedFactory : MonoBehaviour
{
    public bool isFollowingMouse = true;
    public bool loadBetweenScenes = false;

    void OnMouseDown()
    {
        isFollowingMouse = true; 
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowingMouse)
        {
            //give the factory instance a separate script that will check to see if it should still follow the mouse.
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
