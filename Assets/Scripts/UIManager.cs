using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] Image healthBar;
    [SerializeField] Image fuelBar;

    [SerializeField] GameObject gameWin;
    [SerializeField] TextMeshProUGUI gameWinTimerText;
    [SerializeField] GameObject gameLose;

    [SerializeField] GameObject pauseMenu;
    [SerializeField] Button pauseBtn;

    bool isPaused = false;
    bool isGameEnded = false;


    public static UIManager Instance;

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
        
        TimeSpan t = TimeSpan.FromSeconds(TimeManager.Instance.Timer());
                string timerStr = string.Format("{0:D2}:{1:D2}:{2:D3}", 
                t.Minutes, 
                t.Seconds, 
                t.Milliseconds);
        timerText.text = timerStr;


        healthBar.fillAmount = HealthSystem.Instance.HealthPercentage();
        fuelBar.fillAmount = WeaponController.Instance.FuelPercentage();



        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                Cont();
            }
            else{
                Pause();
            }

            
        }


    }

    public void Pause()
    {

        if(isGameEnded)
        {
            return;
        }
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        isPaused = true;
        pauseBtn.gameObject.SetActive(false);
        AudioManager.Instance.aSource.Stop();
        WeaponController.Instance.isGameStopped = true;
    }

    public void Cont()
    {
        
        if(isGameEnded)
        {
            return;
        }

        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        isPaused = false;
        pauseBtn.gameObject.SetActive(true);
        WeaponController.Instance.isGameStopped = false;
    }


    public void ReturnMainMenu()
    {
        isGameEnded = true;
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void ShowWinScreen()
    {
        isGameEnded = true;
        Time.timeScale = 0;

        gameWin.SetActive(true);


        TimeSpan t = TimeSpan.FromSeconds(TimeManager.Instance.Timer());
                string timerStr = string.Format("{0:D2}:{1:D2}:{2:D3}", 
                t.Minutes, 
                t.Seconds, 
                t.Milliseconds);
        gameWinTimerText.text = timerStr;
        AudioManager.Instance.aSource.Stop();
        WeaponController.Instance.isGameStopped = true;

    }
    public void ShowLoseScreen()
    {
        AudioManager.Instance.aSource.Stop();
        isGameEnded = true;
        Time.timeScale = 0;
        gameLose.SetActive(true);
        WeaponController.Instance.isGameStopped = true;

    }
}
