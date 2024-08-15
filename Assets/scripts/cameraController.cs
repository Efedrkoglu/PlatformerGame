using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 offset;
    private Vector3 desiredPos;
    private Quaternion targetRotation;
    private float xRotation;
    private float yRotation;
    [SerializeField] private float camSensitivity;
    void Start()
    {
        
        offset = target.position - transform.position;
    }

    void Update()
    {
        xRotation += Input.GetAxis("Mouse Y") * camSensitivity * -1;
        yRotation += Input.GetAxis("Mouse X") * camSensitivity;
    }

    private void LateUpdate() {
        targetRotation = Quaternion.Euler(xRotation, yRotation, 0);

        desiredPos = target.position - targetRotation * offset;

        transform.SetPositionAndRotation(desiredPos, targetRotation);
        transform.LookAt(target.position);
    }

    public Quaternion YRotation() {
        return Quaternion.Euler(0.0f, yRotation, 0.0f);
    }
}
