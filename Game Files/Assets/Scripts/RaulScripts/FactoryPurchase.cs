using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryPurchase : MonoBehaviour
{
    private GameObject factoryInstance;
    [SerializeField]
    GameObject factoryGameObject;
    
    public void PurchaseFactory()
    {
        factoryInstance = GameObject.Instantiate(factoryGameObject);
    }

    private void Update()
    {
        if (factoryInstance != null)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            mousePos.z = 0;
            factoryInstance.transform.position = mousePos;
        }
        
    }
}
