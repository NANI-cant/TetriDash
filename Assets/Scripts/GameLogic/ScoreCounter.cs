using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreCounter : MonoBehaviour
{
    private CombinationDestroyer _destroyer;
    [SerializeField] private float score;
    public UnityAction<float> OnScoreChange;

    private void OnEnable(){
        _destroyer = FindObjectOfType<CombinationDestroyer>();
        _destroyer.OnCombinationDestroyEnd += AddPoint;
    }

    private void AddPoint(){
        score++;
        OnScoreChange?.Invoke(score);
    }
}
