using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardWindow : MonoBehaviour
{
    [SerializeField] private UIActivator _ui;
    public AdMob adMob;

    public void ContinueGame(){
        adMob.TryToShowRewardedAd();
        //_ui.ContinueGame();
    }

    public void EndGame(){
        _ui.FinishGame();
    }
}
