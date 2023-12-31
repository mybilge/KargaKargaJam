using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    Camera mainCam;
    Rigidbody2D rb;
    bool engineIsOn = false;

    [SerializeField] private Transform gunHolder;
    [SerializeField] private Transform gunTip;
    

    [Header("Gun Settings")]
    [SerializeField] ParticleSystem fireExtingSmoke;
    [SerializeField] float gunForce =50f;
    [SerializeField] float pushBackForce;
    [SerializeField] float maxFuel = 5f;
    float fuel = 5f;
    bool canFuel = true;
    [SerializeField] float fuelDecreasingAmount = 1f;
    [SerializeField] float fuelIncreasingAmount = 1f;

    public bool isGameStopped = false;


    AudioSource audioSource;

    public static WeaponController Instance;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        if(Instance == null)
        {   
            Instance = this;
        }
        else{
            Destroy(this);
        }
        
        fuel = maxFuel;
    }
    private void Start() {
        mainCam = Camera.main;
        fuel = maxFuel;
        audioSource = AudioManager.Instance.aSource;
    }
    
    void Update()
    {

        Vector2 dir = mainCam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        gunHolder.rotation = Quaternion.AngleAxis(angle-65,Vector3.forward);


        if(Input.GetMouseButton(0) && fuel > 0)
        {
            engineIsOn = true;
            canFuel = false;
        }

        if(Input.GetMouseButtonUp(0))
        {
            engineIsOn = false;
            canFuel = true;
        }

        if(engineIsOn)
        {
            if(!audioSource.isPlaying && !isGameStopped)
            {
                audioSource.Play();
            }
            if(!fireExtingSmoke.isPlaying)
            {
                fireExtingSmoke.Play();
            }
            
        }
        else {
            if(audioSource.isPlaying)
            {
                audioSource.Pause();
            }
            if(fireExtingSmoke.isPlaying)
            {
                fireExtingSmoke.Stop();
            }
        }


        

    }

    private void FixedUpdate() {
        //Debug.Log(transform.position-gunTip.position);

        //Debug.Log(fuel);

        if(fuel<=0)
        {
            engineIsOn = false;
        }

        if(engineIsOn)
        {

            fuel -= Time.fixedDeltaTime * fuelDecreasingAmount;
            rb.AddForce(gunForce*(transform.position-gunTip.position).normalized, ForceMode2D.Force);
        }
        else
        {

            if(canFuel)
            {
                fuel += Time.fixedDeltaTime * fuelIncreasingAmount;
            }
            
            //rb.AddForce(Vector2.zero,ForceMode2D.Force);
        }

        fuel = Mathf.Clamp(fuel, 0, maxFuel);
    }

    public bool EngineIsOn()
    {
        return engineIsOn;
    }

    public float PushBackForce()
    {
        return pushBackForce;
    }

    public float FuelPercentage()
    {
        return fuel/maxFuel;
    }

}
