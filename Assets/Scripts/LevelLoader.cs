﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private GameInformer _informer;

    private void Start(){
        if(FindObjectOfType<TopLineChecker>()!=null){
            FindObjectOfType<TopLineChecker>().OnGameFinish += InvokeLoadScene;
        }
        _informer = GameInformer.Singleton;
        if(!_informer.IsFirstEnter){
            GetComponent<Animator>().SetTrigger("EnterScene");
        }
    }

    public void LoadScene(){
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