using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class InGameScoreShower : MonoBehaviour
{
    private TextMeshProUGUI _scoreTM;
    private ScoreCounter _counter;

    private void Awake(){
        _scoreTM = GetComponent<TextMeshProUGUI>();
        _scoreTM.SetText("0");
        _counter = FindObjectOfType<ScoreCounter>();
        _counter.OnScoreChange+=ChangeUI;
    }

    private void ChangeUI(float newScore){
        _scoreTM.SetText(newScore.ToString());
    }
}
