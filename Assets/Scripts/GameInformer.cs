using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class GameInformer : MonoBehaviour
{
    public static GameInformer Singleton {get ; private set;}

    public bool IsFirstEnter;
    public float CurrentScore;
    public float BestScore;

    private void Awake(){
        if(Singleton == null){
            Singleton = this;
            DontDestroyOnLoad(this.gameObject);
        }else{
            Destroy(this.gameObject);
        }

        IsFirstEnter = true;

        if(PlayerPrefs.HasKey("BestScore")){
            CurrentScore = BestScore = PlayerPrefs.GetFloat("BestScore");
        }else{
            CurrentScore = BestScore = 0f;
        }
    }

    public void SetEnter(bool state){
        IsFirstEnter = state;
    }

    public void SetNewScore(float score){
        CurrentScore = score;
    }
    
    public void CompareScores(){
        if(CurrentScore>BestScore){
            BestScore = CurrentScore;
        }
    }
}
