using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallHandler : MonoBehaviour
{
    private Vector3 pendingVelocity = Vector3.zero;
    private Rigidbody rb;
    private Vector3 spawnPoint;

    [SerializeField]
    private float gainRate = 10f;
    [SerializeField]
    private GameObject streakCounter;

    private int maxStreak = 0;
    private int streak = 0;
    private Text streakText;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(Random.value, Random.value, Random.value);
        spawnPoint = transform.position;
        streakText = streakCounter.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        streakText.text = string.Format("Streak: {0:D}\nMax: {1:D}", streak, maxStreak);
    }

    void FixedUpdate()
    {
        if(pendingVelocity != Vector3.zero)
        {
            rb.velocity = pendingVelocity;
            pendingVelocity = Vector3.zero;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Vector3 currentDirection = (rb.velocity + pendingVelocity).normalized;
        Vector3 newDirection = (collision.contacts[0].point - rb.position).normalized * -1;
        newDirection = (currentDirection + newDirection) / 2;
        pendingVelocity = newDirection * (rb.velocity.magnitude + gainRate);
        
        if(collision.gameObject.name == "Player")
        {
            streak++;
        }
    }

    public void respawn()
    {
        if(streak > maxStreak)
        {
            maxStreak = streak;
        }
        streak = 0;
        transform.position = spawnPoint;
        rb.velocity = rb.velocity.normalized;
    }


}
