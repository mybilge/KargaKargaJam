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
        rb = GetComponent<Rigidbody2D>();
        

        InvokeRepeating("UpdatePath", 0, 0.5f);
    }

    void UpdatePath()
    {
        if(seeker.IsDone()){
            seeker.StartPath(rb.position,target.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    private void FixedUpdate() {
        
        if(path == null)
        {
            return;
        }

        if(currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else{
            reachedEndOfPath = false;
        }
    
        Vector2 direction = ((Vector2) path.vectorPath[currentWaypoint] -rb.position).normalized;
        Vector2 force =  speed * Time.deltaTime  * direction;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);


        if(currentWaypoint == path.vectorPath.Count-1)
        {
            if(distance <= 1)
            {
                currentWaypoint++;
            }
        }
        else{
            if(distance < nextWaypointDistance)
            {
                currentWaypoint++;
            }
        }

        

    }

    float timer = 0f;

    private void OnCollisionStay2D(Collision2D other) {
        
    }
}
