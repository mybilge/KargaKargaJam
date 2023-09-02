using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    Camera mainCam;
    [SerializeField] private Transform gunHolder;
    [SerializeField] private Transform gunTip;
    Rigidbody2D rb;

    [SerializeField] float gunForce =50f;
    bool engineIsOn = false;

    [SerializeField] PushBack pb;

    [SerializeField] float pushBackForce;

    public bool EngineIsOn()
    {
        return engineIsOn;
    }


    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start() {
        mainCam = Camera.main;
        pb.SetPushBackForce(pushBackForce);
    }
    
    void Update()
    {

        Vector2 dir = mainCam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        gunHolder.rotation = Quaternion.AngleAxis(angle,Vector3.forward);


        if(Input.GetMouseButtonDown(0))
        {
            engineIsOn = true;
        }

        if(Input.GetMouseButtonUp(0))
        {
            engineIsOn = false;
        }
    }

    private void FixedUpdate() {
        //Debug.Log(transform.position-gunTip.position);
        if(engineIsOn)
        {
            rb.AddForce(gunForce*(transform.position-gunTip.position).normalized, ForceMode2D.Force);
        }
        else
        {
            rb.AddForce(Vector2.zero,ForceMode2D.Force);
        }
    }
}
