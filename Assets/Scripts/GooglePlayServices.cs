using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class GooglePlayServices : MonoBehaviour
{
    public static GooglePlayServices GPSSingleton { get; private set; }

    private readonly string leaderBoard = "CgkIjv69vLkUEAIQAQ";

    private void Awake()
    {
        if (GPSSingleton == null){
            GPSSingleton = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else{
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate(success => {
            if(success){
                Debug.Log("Authorization success");
            }else{
                Debug.Log("Authorization fail");
            }
        });
    }

    public void AddPointsToLeaderBoard(float newScore){
        Social.ReportScore((long)newScore,leaderBoard,(bool success)=>{
            if(success){
                Debug.Log("Score writing success");
            }else{
                Debug.Log("Score writing fail");
            }
        });
    }

    public void ShowLeaderBoard(){
        Debug.Log("Show LB");
        Social.ShowLeaderboardUI();
    }

    public void ExitFromGPS(){
        Debug.Log("ExitFromGPS");
        PlayGamesPlatform.Instance.SignOut();
    }
}
