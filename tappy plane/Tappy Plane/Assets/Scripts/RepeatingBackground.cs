using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    [Tooltip("How fast should this object move")]
    public float scrollspeed;

    //How far to move until the object is offscreen
    public const float ScrollWidth = 8; //bg width//pixels per unit

    //Called at a fixed time frame, move the objects and if they are off the screen do the appropriate thing 
    private void FixedUpdate()
    {
        //Grab my current position 
        Vector3 pos = transform.position;

        //Move the object a certain amount to the left
        //negatvie in the x axis
        pos.x -= scrollspeed * Time.deltaTime * GameController.speedModifier;

        //Check if object is now fully offscreen
        if (transform.position.x < -ScrollWidth)
        {
            Offscreen(ref pos);
        }
        //if not destroyed, set our new position
        transform.position = pos;
    }

    //called whenever the object this is attached to goes completely off-screen 
    //<param name = "pos" > reference to position </param>
    protected virtual void Offscreen(ref Vector3 pos)
    {
        //Moves the object to be to off-screen on the right side
        pos.x += 2 * ScrollWidth;
    }
}
