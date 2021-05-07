using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreCounter : MonoBehaviour
{
    private CombinationDestroyer _destroyer;
    [SerializeField] private float score = 0;
    public UnityAction<float> OnScoreChange;

    private void Start(){
        FindObjectOfType<TopLineChecker>().OnGameFinish+=SaveBest;
        _destroyer = FindObjectOfType<CombinationDestroyer>();
        _destroyer.OnCombinationDestroyEnd += AddPoint;
    }

    private void AddPoint(){
        score++;
        OnScoreChange?.Invoke(score);
    }

    private void SaveBest(){
        GameInformer.Singleton.SetNewScore(score);
        if(PlayerPrefs.HasKey("BestScore")){
            if(PlayerPrefs.GetFloat("BestScore") < score){
                PlayerPrefs.SetFloat("BestScore", score);
            }
        }else{
            PlayerPrefs.SetFloat("BestScore", score);
        }
    }
}
