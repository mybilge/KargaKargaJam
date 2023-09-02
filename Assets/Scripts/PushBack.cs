using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBack : MonoBehaviour
{

    float pushBackForce = 10f;

    public void SetPushBackForce(float ff)
    {
        pushBackForce = ff;
    }

    [SerializeField] WeaponController wc;
    private void OnTriggerStay2D(Collider2D other) {

       if(!wc.EngineIsOn())
       {
            return;
       }

        if(other.TryGetComponent<Rigidbody2D>(out Rigidbody2D rb))
        {
            Vector3 dir = other.transform.position - transform.position;
            rb.AddForce(pushBackForce * dir.normalized);
        }
    }
}
