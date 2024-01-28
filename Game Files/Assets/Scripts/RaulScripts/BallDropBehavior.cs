using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script moves the ball back and forth above the pegboard before dropping as well as 
 * releases the ball when the player hits space.
 * 
 * This script should be attached to the ball that will drop on the plinko board.
 */
public class BallDropBehavior : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The leftmost x position that the ball that is going to drop should not pass.")]
    private float beginningXPosition;

    [SerializeField]
    [Tooltip("The rightmost x position that the ball that is going to drop should not pass.")]
    private float endXPosition;

    [SerializeField]
    [Tooltip("This is the speed at which the ball should move back and forth from beginning to end positions.")]
    private float displacementSpeed = 1;

    private bool _left = true;
    private bool _shouldDisplace = true;
    // Update is called once per frame
    void FixedUpdate()
    {
        if(this.gameObject.transform.position.x < beginningXPosition)
        {
            _left = true;
        }
        else if(this.gameObject.transform.position.x > endXPosition)
        {
            _left = false;
        }

        if (_shouldDisplace)
        {
            if (_left)
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
            _shouldDisplace = false;
        }
    }
}
