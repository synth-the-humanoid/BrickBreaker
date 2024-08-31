using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTriggerHandler : MonoBehaviour
{
    [SerializeField]
    private int lives = 1;
    [SerializeField]
    private GameObject brickCollection;
    [SerializeField]
    private GameObject livesCounter;
    private Text livesText;

    private int startingLives;

    private void SetLivesCounter()
    {
        livesText.text = string.Format("Lives: {0:D}", lives);
    }

    // Start is called before the first frame update
    void Start()
    {
        startingLives = lives;
        livesText = livesCounter.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lives == 0)
        {
            lives = startingLives;
            BrickSpawner brickSpawner = brickCollection.GetComponent<BrickSpawner>();
            if (brickSpawner != null)
            {
                brickSpawner.cleanBricks();
                brickSpawner.spawnBricks();
            }
            
        }
        else
        {
            SetLivesCounter();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        BallHandler ballHandler = other.GetComponent<BallHandler>();
        if (ballHandler != null)
        {
            lives -= 1;
            if(lives != 0)
            {
                ballHandler.respawn();
                BrickSpawner brickSpawner = brickCollection.GetComponent<BrickSpawner>();
                if(brickSpawner != null)
                {
                    PlayerController playerController = brickSpawner.playerObject.GetComponent<PlayerController>();
                    if(playerController != null)
                    {
                        playerController.respawn();
                    }
                }
            }
        }
    }
}
