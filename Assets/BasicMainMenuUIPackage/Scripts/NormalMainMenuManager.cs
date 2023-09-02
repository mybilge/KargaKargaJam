using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NormalMainMenuManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI usernameScoreText;


    private void Start() {
        ShowUsernameScore();
        //LeaderboardManager.Instance.SetLeaderboardEntry(PlayerPrefs.GetString("Username"),PlayerPrefs.GetInt("BestScore"));
    }
    void ShowUsernameScore()
    {
        usernameScoreText.text = "Username: " + PlayerPrefs.GetString("Username") 
                                + "\nBest Time: " + (PlayerPrefs.GetInt("BestScore")/100f).ToString();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    private void OnEnable() {
        //Debug.Log(PlayerPrefs.GetString("Username")+ " "+PlayerPrefs.GetInt("BestScore"));
        if(PlayerPrefs.GetInt("BestScore")!=0)
        {
            LeaderboardManager.Instance.SetLeaderboardEntry(PlayerPrefs.GetString("Username"),PlayerPrefs.GetInt("BestScore"));
        }
        
        ShowUsernameScore();
    }
}
