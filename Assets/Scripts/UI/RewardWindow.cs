using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardWindow : MonoBehaviour
{
    [SerializeField] private UIActivator _ui;

    public void ContinueGame(){
        _ui.ContinueGame();
    }

    public void EndGame(){
        _ui.FinishGame();
    }
}
