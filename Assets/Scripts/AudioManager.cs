using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] private AudioClip backLoop;
    [SerializeField] AudioClip smokeSound;
    // Start is called before the first frame update
    public AudioSource aSource;


    public static AudioManager Instance;
    private void Awake() {

        if(Instance == null)
        {
            Instance = this;
        }
        else{
            Destroy(this);
        }

        aSource = GetComponent<AudioSource>();
        

    }



    

    
}
