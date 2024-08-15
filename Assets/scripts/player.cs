using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float force;
    [SerializeField] private float maxSpeed;
    private cameraController cam;
    private Vector3 movementDir;
    private Vector3 desiredMovementDir;
    private bool grounded;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<cameraController>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        movementDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        desiredMovementDir = cam.YRotation() * movementDir;
        rb.AddForce(desiredMovementDir * force * Time.deltaTime, ForceMode.VelocityChange);

        Vector3 horizontalVelocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        if (horizontalVelocity.magnitude > maxSpeed)
        {
            horizontalVelocity = horizontalVelocity.normalized * maxSpeed;
            rb.velocity = new Vector3(horizontalVelocity.x, rb.velocity.y, horizontalVelocity.z);
        }

        if(Input.GetKeyDown(KeyCode.Space) && grounded) {
            audioSource.Play();
            grounded = false;
            rb.AddForce(new Vector3(0, 300.0f, 0));
        }
    }

    private void OnCollisionEnter(Collision other) {
        grounded = true;
    }
}
