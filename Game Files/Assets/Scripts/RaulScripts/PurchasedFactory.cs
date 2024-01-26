using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchasedFactory : MonoBehaviour
{
    public bool isFollowingMouse = true;
    // Start is called before the first frame update
    void Start()
    {
        
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
    }
}
