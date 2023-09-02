using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class AIForEnemy : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float nextWaypointDistance = 2f;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    Seeker seeker;
    Rigidbody2D rb;
     

    private void Start() {
        seeker = GetComponent<Seeker>();
        seeker.StartPath(rb.position,target.position);
    }
}
