using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartBehaviour : MonoBehaviour
{
    //a reference to the player object
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("planeBlue1");
        player.GetComponent<Rigidbody2D>().isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Start the game
        if((Input.GetKeyUp("space") || Input.GetMouseButtonDown(0)))
        {
            //After 1 second spawn obstacles every 1.5 seconds
            GameController controller = GetComponent<GameController>();
            controller.InvokeRepeating("CreateObstacle", 1f, 1.5f);

            //we want the plane to start falling now
            player.GetComponent<Rigidbody2D>().isKinematic = false;

            //Just delete this component, not the object it's attached to
            Destroy(this);
        }
    }
}
