using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum BrickType
{
    WEAK = 0,
    MEDIUM = 1,
    STRONG = 2
}

public class BrickSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject brick;
    [SerializeField]
    public GameObject ballObject;
    [SerializeField]
    public GameObject playerObject;
    [SerializeField]
    private Vector3 topLeft = Vector3.zero;
    [SerializeField]
    private Vector3 bottomRight = Vector3.zero;
    [SerializeField]
    private float spacing = .5f;
    [SerializeField]
    private BrickType[] allowedTypes;

    private bool gameStarted = false;
    private BallHandler ballHandler;

    private BrickType getRandomType()
    {
        BrickType[] copy = (BrickType[])allowedTypes.Clone();
        int index = Random.Range(0, copy.Length);
        return copy[index];
    }

    public void cleanBricks()
    {
        BrickHandler[] handlers = transform.GetComponentsInChildren<BrickHandler>();
        foreach(BrickHandler handler in handlers)
        {
            Destroy(handler.gameObject);
        }
    }
    
    public void spawnBricks()
    {
        Vector3 currentPos = topLeft;
        currentPos.y -= spacing;
        currentPos.z -= spacing;

        GameObject newBrick = null;
        while (currentPos.y >= bottomRight.y)
        {
            while (currentPos.z >= bottomRight.z)
            {
                newBrick = Instantiate(brick, transform.position + currentPos, Quaternion.identity);
                newBrick.GetComponent<BrickHandler>().BrickType = getRandomType();
                newBrick.transform.parent = transform;
                currentPos.z -= (newBrick.transform.localScale.z + spacing);
            }
            currentPos.z = topLeft.z - spacing;
            currentPos.y -= (newBrick.transform.localScale.y + spacing);
        }
        BallHandler ballHandler = ballObject.GetComponent<BallHandler>();
        if(ballHandler != null)
        {
            ballHandler.respawn();
        }
        PlayerController playerController = playerObject.GetComponent<PlayerController>();
        if(playerController != null && gameStarted)
        {
            playerController.respawn();
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        spawnBricks();
        gameStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount == 0)
        {
            spawnBricks();
        }
    }
}
