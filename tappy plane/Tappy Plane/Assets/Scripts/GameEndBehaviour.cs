using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndBehaviour : MonoBehaviour
{
    //Stops the player from quiting the game until a certain amount of time has passed
    private bool canQuit = false;

    /// <summary>
    /// //We've lost the game so stop spawning obstacles
    /// </summary>
    // Start is called before the first frame update
    void Start()
    {
        //Start our timer coroutine
        StartCoroutine(DelayQuit());

        //We no longer need to spawn obstacles 
        GameController controller = GameObject.Find("GameController").GetComponent<GameController>();
        controller.CancelInvoke();
    }

    // Update is called once per frame
    //Checks if the player presses space or clicks the mouse. If we can restart, we will
    void Update()
    {
        if ((Input.GetKeyUp("space") || Input.GetMouseButtonDown(0)) && canQuit)
        {
            //will restart up to the same level as we are currently playing 
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    //Delays the player being able to restart instantly 
    //<returns> how long to wait before being called again /returns>
    IEnumerator DelayQuit()
    {
        //Give the player time before we end the game 
        yield return new WaitForSeconds(.5f);

        //After .5 seconds have passed it will come here
        canQuit = true;
    }
}
