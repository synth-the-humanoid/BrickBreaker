using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 pendingVelocity;
    private Rigidbody rb;
    private Vector3 startPos;

    [SerializeField]
    private float speed = 1.0f;
    
    private Vector3 getInputVelocity()
    {
        float horizInput = Input.GetAxis("Horizontal");
        return new Vector3(0, 0, -1 * horizInput) * speed;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        pendingVelocity = Vector3.zero;
        rb = transform.GetComponent<Rigidbody>();
        startPos = rb.position;
    }

    // Update is called once per frame
    void Update()
    {
        pendingVelocity = getInputVelocity();
    }

    void FixedUpdate()
    {
        rb.velocity = pendingVelocity;
        pendingVelocity = Vector3.zero;
    }

    public void respawn()
    {
        rb.position = startPos;
    }
}
