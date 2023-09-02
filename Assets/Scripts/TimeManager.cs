using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    
    
    float timer;
    bool isEnded = false;


    public static TimeManager Instance;

    private void Awake() {
        if(Instance == null)
        {
            Instance = this;
        }
        else{
            Destroy(this);
        }
    }

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

            GameEndWin();
        }
    }    

    void GameEndWin()
    {
        Time.timeScale = 0;

        if(PlayerPrefs.GetInt("BestScore") > (int)(timer*100) || PlayerPrefs.GetInt("BestScore") ==0)
        {
            PlayerPrefs.SetInt("BestScore", (int)(timer*100));
        }

    }

    public void GameEndLose()
    {
        Time.timeScale = 0;
    }


    void ReturnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
