using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBack : MonoBehaviour
{

    WeaponController wc;
    private void Start() {
        wc = WeaponController.Instance;
    }

    private void OnTriggerStay2D(Collider2D other) {

        if(!wc.EngineIsOn())
        {
            return;
        }

        if(other.TryGetComponent<Rigidbody2D>(out Rigidbody2D rb))
        {
            Vector3 dir = other.transform.position - transform.position;
            rb.AddForce(wc.PushBackForce() * dir.normalized);
        }
    }
}
