using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDropBehavior : MonoBehaviour
{
    [SerializeField]
    [Tooltip("")]
    private float beginningXPosition;

    [SerializeField]
    [Tooltip("")]
    private float endXPosition;

    bool left = true;
    // Update is called once per frame
    void FixedUpdate()
    {
        if(this.gameObject.transform.position.x < beginningXPosition)
        {
            left = true;
        }
        else if(this.gameObject.transform.position.x > endXPosition)
        {
            left = false;
        }

        if (left)
        {
            this.gameObject.transform.Translate(Vector3.right * Time.deltaTime, Space.World);
        }
        else
        {
            this.gameObject.transform.Translate(-Vector3.right * Time.deltaTime, Space.World);
        }
    }
}
