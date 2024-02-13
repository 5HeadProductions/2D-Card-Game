using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GaneEnd : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < this.transform.childCount; i++) {
            if(this.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().enabled == true)
            {
                break;
            }

            if(i == this.transform.childCount - 1)
            {
                SceneManager.LoadScene("EndScene");
            }
        }
    }
}
