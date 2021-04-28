using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Settings : MonoBehaviour
{
    [SerializeField] private AnimationCurve timeToSpawnCurwe;
    [SerializeField] private AnimationCurve figureSpeedCurwe;
    [SerializeField] private float currentFigureSpeed;
    [SerializeField] private float currentTimeToSpawn;
    private ScoreCounter _scoreCounter;
    public UnityAction<float> OnSpeedChange;
    public UnityAction<float> OnSpawnTimeChange;

    private void Awake(){
        _scoreCounter = GetComponent<ScoreCounter>();
        _scoreCounter.OnScoreChange += ChangeSettings;
        currentFigureSpeed = figureSpeedCurwe.Evaluate(0);
        currentTimeToSpawn = timeToSpawnCurwe.Evaluate(0);
    }

    private void ChangeSettings(float score){
        currentFigureSpeed = figureSpeedCurwe.Evaluate(score);
        currentTimeToSpawn = timeToSpawnCurwe.Evaluate(score);
        OnSpeedChange?.Invoke(currentFigureSpeed);
        OnSpawnTimeChange?.Invoke(currentTimeToSpawn);
    }

    public float GetSpeed(){
        return currentFigureSpeed;
    }

    public float GetSpawnTime(){
        return currentTimeToSpawn;
    }
}
