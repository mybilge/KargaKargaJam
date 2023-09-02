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
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void ShowWinScreen()
    {
        Time.timeScale = 0;

        gameWin.SetActive(true);


        TimeSpan t = TimeSpan.FromSeconds(TimeManager.Instance.Timer());
                string timerStr = string.Format("{0:D2}:{1:D2}:{2:D3}", 
                t.Minutes, 
                t.Seconds, 
                t.Milliseconds);
        gameWinTimerText.text = timerStr;

    }
    public void ShowLoseScreen()
    {
        Time.timeScale = 0;
        gameLose.SetActive(true);

    }
}
