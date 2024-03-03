using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * This class loads a new scene when the Plinko ball lands and also either increases or decreases
 * currency depending on the type of bucket it lands in.
 * 
 * This component should be attached to the buckets at the bottom of the plinko board.
 */
public class rewardBuckets : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Buckets that will give a benefit should have this checked")]
    private bool _isReward;

    [SerializeField]
    private int _rewardAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isReward)
        {
            CurrencyManager.instance.TotalCurrency += _rewardAmount;
            
        }
        else
        {
            if(CurrencyManager.instance.TotalCurrency - _rewardAmount < 0)
            {
                CurrencyManager.instance.TotalCurrency = 0;
            }
            else
            {
                CurrencyManager.instance.TotalCurrency -= _rewardAmount;
            }
        }
        SceneManager.LoadScene("FactoryPurchasing");
    }

}
