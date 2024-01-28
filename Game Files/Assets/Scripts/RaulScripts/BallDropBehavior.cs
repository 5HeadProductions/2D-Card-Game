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

    [SerializeField]
    [Tooltip("")]
    private float displacementSpeed = 1;

    bool left = true;
    bool shouldDisplace = true;
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

        if (shouldDisplace)
        {
            if (left)
            {
                this.gameObject.transform.Translate(Vector3.right * Time.deltaTime * displacementSpeed, Space.World);
            }
            else
            {
                this.gameObject.transform.Translate(-Vector3.right * Time.deltaTime * displacementSpeed, Space.World);
            }
        }
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            shouldDisplace = false;
        }
    }
}
