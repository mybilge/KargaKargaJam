using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    
    
    float timer;
    bool isEnded = false;

    private void Update() {
        if(!isEnded)
        {
            timer+= Time.deltaTime;
            //Debug.Log(timer);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            isEnded = true;

            GameEnd();
        }
    }    

    void GameEnd()
    {

    }
}
