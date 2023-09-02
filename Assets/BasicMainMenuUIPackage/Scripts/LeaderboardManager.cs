using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


using Dan.Main;
using System;

public class LeaderboardManager : MonoBehaviour
{
    [SerializeField] List<TextMeshProUGUI> names;
    [SerializeField] List<TextMeshProUGUI> scores;

    
    public static LeaderboardManager Instance;


    private void Awake() {

        if(Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;


        for (int i = 0; i < names.Count; i++)
        {
            names[i].text = "";
            scores[i].text = "";
        }
    }



    string leaderboardPublicKey = "4cc86302903c1f1b5927f44acb71d7df6bdc824e048821e0141b2237d4d45e1b";
    public void GetLeaderboard()
    {
        LeaderboardCreator.GetLeaderboard(leaderboardPublicKey,((msg)=>
        {
            int loopLength = (msg.Length<names.Count)?msg.Length:names.Count;
            //Debug.Log(msg.Length);

            int a = 0;

            for (int i = 0; i < loopLength; i++)
            {
                if(msg[i].Score <= 0)
                {
                    continue;
                }
                names[a].text = msg[i].Username;
                scores[a].text = msg[i].Score.ToString();
                a++;
            }
        }));
    }

    public void SetLeaderboardEntry(string username, int score)
    {
        LeaderboardCreator.UploadNewEntry(leaderboardPublicKey, username,score,((msg)=>
        {
            GetLeaderboard();
        }));
    }

    public void IsUsernameAlreadyExist(string username, Action goNext, Action<bool> fail)
    {

        LeaderboardCreator.GetLeaderboard(leaderboardPublicKey, ((msg) =>
        {
            bool isFail = false;
            for (int i = 0; i < msg.Length; i++)
            {
                if(msg[i].Username == username)
                {   
                    isFail = true;
                    break;
                }
            }

            if(!isFail)
            {
                goNext();
            }
            else{
                fail(true);
            }
        }));
    }

    


}
