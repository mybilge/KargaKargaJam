using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed;
    [SerializeField] float nextWaypointDistance = 2f;
    [SerializeField] float updatePathRepeatingTime = 0.1f;
    [SerializeField] float damageRepeatingTime = 1f;


    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    Seeker seeker;
    Rigidbody2D rb;
    float timer = 0f;
    bool canHit = true;
     

    private void Start() {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0, updatePathRepeatingTime);
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


        timer += Time.fixedDeltaTime;
        if(timer >= damageRepeatingTime)
        {
            canHit = true;
        }


        
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

    

    private void OnTriggerStay2D(Collider2D other) {

        if (!canHit)
        {
            return;
        }
        
        if(!other.transform.CompareTag("Player"))
        {
            return;
        }

        //hasar ver

        if(other.transform.TryGetComponent<HealthSystem>(out HealthSystem hs))
        {
            hs.GetDamage();
            canHit = false;
            timer = 0;
        }
    }
}
