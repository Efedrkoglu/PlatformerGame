using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving_platform : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed;
    private Transform currentWaypoint;
    private int waypointIndex;
    void Start()
    {
        waypointIndex = 0;
        currentWaypoint = waypoints[waypointIndex];
    }

    void Update()
    {
        if(Vector3.Distance(transform.position, currentWaypoint.transform.position) > .1f) {
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, speed * Time.deltaTime);
        }
        else {
            waypointIndex += 1;
            if(waypointIndex == waypoints.Length) {
                waypointIndex = 0;
            }

            currentWaypoint = waypoints[waypointIndex];
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")) {
            other.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("Player")) {
            other.gameObject.transform.SetParent(null);
        }
    }
}
