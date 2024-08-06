using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private Rigidbody rb;
    public float force;
    public float maxSpeed;
    private cameraController cam;
    private Vector3 movementDir;
    private Vector3 desiredMovementDir;
    private bool grounded;
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<cameraController>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        movementDir = new Vector3(Input.GetAxis("Horizontal") * force, 0, Input.GetAxis("Vertical") * force);
        desiredMovementDir = cam.YRotation() * movementDir;
        rb.AddForce(desiredMovementDir);

        Vector3 horizontalVelocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        if (horizontalVelocity.magnitude > maxSpeed)
        {
            horizontalVelocity = horizontalVelocity.normalized * maxSpeed;
            rb.velocity = new Vector3(horizontalVelocity.x, rb.velocity.y, horizontalVelocity.z);
        }

        if(Input.GetKeyDown(KeyCode.Space) && grounded) {
            grounded = false;
            rb.AddForce(new Vector3(0, 250.0f, 0));
        }
    }

    private void OnCollisionEnter(Collision other) {
        grounded = true;
    }
}
