using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryPurchase : MonoBehaviour
{
    private GameObject factoryInstance;

    [SerializeField]
    GameObject factoryGameObject;
    
    //Function is meant to be called with a button press, Instantiates a draggable factory.
    public void PurchaseFactory()
    {
        factoryInstance = GameObject.Instantiate(factoryGameObject);
    }

    private void Update()
    {
        //When the factory is purchased we make a purchased factory follow the cursor.
        if (factoryInstance != null)
        {
            //give the factory instance a separate script that will check to see if it should still follow the mouse.
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            mousePos.z = 0;
            factoryInstance.transform.position = mousePos;
        }
    }
}
