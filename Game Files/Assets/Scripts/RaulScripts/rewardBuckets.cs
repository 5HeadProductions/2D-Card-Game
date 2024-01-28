using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rewardBuckets : MonoBehaviour
{
    [SerializeField]
    bool isReward;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isReward)
        {
            CurrencyManager.instance.TotalCurrency++;
            SceneManager.LoadScene("FactoryPurchasing");
        }
        else
        {
            CurrencyManager.instance.TotalCurrency--;
            SceneManager.LoadScene("FactoryPurchasing");
        }
    }

}
