using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIActivator : MonoBehaviour
{
    [SerializeField] private GameObject rewardWindow;
    private RewardGiver _giver;
    private bool canContinue = true;
    public UnityAction OnGameFinish;
    public UnityAction OnGameContinue;
    private TopLineChecker _topLine;

    private void Awake(){
        rewardWindow.SetActive(false);
        _topLine = FindObjectOfType<TopLineChecker>();
        _topLine.OnGameFinish+=TryToContinue;
        _giver = FindObjectOfType<RewardGiver>();
    }

    private void TryToContinue(){
        if(canContinue){
            Invoke(nameof(ActivateRewardWindow),1f);
        }else{
            OnGameFinish?.Invoke();
        }
    }

    public void ContinueGame(){
        canContinue = false;
        _giver.Give();
        DeactivateRewardWindow();
        OnGameContinue?.Invoke();
    }

    public void FinishGame(){
        DeactivateRewardWindow();
        OnGameFinish?.Invoke();
    }

    private void ActivateRewardWindow(){
        rewardWindow.SetActive(true);
    }

    private void DeactivateRewardWindow(){
        rewardWindow.SetActive(false);
    }
}
