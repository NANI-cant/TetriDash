using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private GameInformer _informer;
    public AdMob adMob;

    private void Start(){
        if(FindObjectOfType<UIActivator>()!=null){
            FindObjectOfType<UIActivator>().OnGameFinish += InvokeLoadScene;
        }
        _informer = GameInformer.Singleton;
        if(!_informer.IsFirstEnter){
            GetComponent<Animator>().SetTrigger("EnterScene");
        }
    }

    public void LoadScene(){
        if(SceneManager.GetActiveScene().name == "Game"){
            adMob.TryToShowInterstitialAd();
        }
        _informer.SetEnter(false);
        GetComponent<Animator>().SetTrigger("ExitScene");
    }

    private void LoadGameScene(){
        SceneManager.LoadScene("Game");
    }

    private void LoadMenuScene(){
        SceneManager.LoadScene("MainMenu");
    }

    private void InvokeLoadScene(){
        Invoke(nameof(LoadScene),2f);
    }
}
