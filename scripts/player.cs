using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private Rigidbody rb;
    public float force;
    public float maxSpeed;
    private camera cam;
    private Vector3 movementDir;
    private Vector3 desiredMovementDir;
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<camera>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        movementDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        desiredMovementDir = cam.YRotation() * movementDir;
        rb.AddForce(desiredMovementDir);

        Vector3 horizontalVelocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        if (horizontalVelocity.magnitude > maxSpeed)
        {
            horizontalVelocity = horizontalVelocity.normalized * maxSpeed;
            rb.velocity = new Vector3(horizontalVelocity.x, rb.velocity.y, horizontalVelocity.z);
        }
    }
}
