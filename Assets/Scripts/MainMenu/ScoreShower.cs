using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreShower : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _stateTM;
    private GameInformer _informer;
    private TextMeshProUGUI _scoreTM;

    private void Start(){
        _scoreTM = GetComponent<TextMeshProUGUI>();
        _informer = GameInformer.Singleton;
        if(_informer.IsFirstEnter){
            _scoreTM.SetText(_informer.BestScore.ToString());
            _stateTM.SetText("Best");
        }else{
            _scoreTM.SetText(_informer.CurrentScore.ToString());
            if(_informer.CurrentScore>_informer.BestScore){
                _stateTM.SetText("NewBest");
                _informer.CompareScores();
            }else{
                _stateTM.SetText(" ");
            }
        }
    }
}
