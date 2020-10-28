using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerBehaviour : MonoBehaviour
{
    [Tooltip("The force which is added when the player jumps")]
    public Vector2 jumpForce = new Vector2(0, 300);

    //if we've been hit, we can no longer jump
    private bool beenHit;
    private Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        beenHit = false;
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    //Will be called after all of the Update functions 
    void LateUpdate()
    {
        //check if we should jump as long as we haven't been hit yet
        if ((Input.GetKeyUp("space") || Input.GetMouseButtonDown(0)) && !beenHit)
        {
            //Reset Velocity and then jump up
            rigidbody2D.velocity = Vector2.zero;
            rigidbody2D.AddForce(jumpForce);
        }
    }

    //if we collide with any of the polygon colliders then we crash
    //<param name= "other"> who we collided with</param>
    private void OnCollisionEnter2D(Collision2D other)
    {
        //we have now been hit
        beenHit = true;
        GameController.speedModifier = 0;

        //the animation should no longer play, so we can set the speed to 0 or destroy it
        GetComponent<Animator>().speed = 0.0f;

        //create a GameEndBehaviour to restart
        if(!gameObject.GetComponent<GameEndBehaviour>())
        {
            gameObject.AddComponent<GameEndBehaviour>();
        }
    }
}
