using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [HideInInspector] //Hides var below
    [Header("Obstacle Information")]

    [Tooltip("The obstacle that we will spawn")]
    public GameObject obstacleReference;

    [Tooltip("Minimum Y value used for obstacle")]
    public float obstacleMinY = -1.3f;

    [Tooltip("Maximum Y value used for Obstacle")]
    public float obstacleMaxY = 1.3f;

    //Affects how fast ojbects with the RepeatingBackground script move.
    public static float speedModifier;

    private static Text scoreText;
    private static int score;

    public static int Score
    {
        get { return score;  }
        set
        {
            score = value;
            scoreText.text = score.ToString();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        speedModifier = 1.0f;
        //InvokeRepeating("CreateObstacle", 1.5f, 1.0f);
        gameObject.AddComponent<GameStartBehaviour>();
        score = 0;
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        Debug.Log(scoreText.name);
    }

    //Creates the obstacle and initializes its position
    void CreateObstacle()
    {
        //spawn offscreen with a random Y
        Instantiate(obstacleReference, new Vector3(RepeatingBackground.ScrollWidth, Random.Range(obstacleMinY, obstacleMaxY), 0.0f), Quaternion.identity);
    }
}
