using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] private AudioClip backLoop;
    [SerializeField] AudioClip deneme;
    // Start is called before the first frame update
    AudioSource aSource;
    private void Awake() {
        aSource = GetComponent<AudioSource>();
        //aSource.clip = backLoop;

    }

    void Update()
    {
        
    }
}
