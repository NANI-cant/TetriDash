﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FigureMover : MonoBehaviour
{
    public float SpeedOfFigure;
    private bool canMove = true;
    private CombinationDestroyer _destroyer;
    private Transform _transform;
    private Rigidbody2D _rigidbody;
    private Settings _settings;

    private void Start()
    {
        _settings = FindObjectOfType<Settings>();
        _settings.OnSpeedChange+=ChangeSpeed;
        SpeedOfFigure = _settings.GetSpeed();
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody2D>();
        _destroyer = FindObjectOfType<CombinationDestroyer>();
        _destroyer.OnCombinationDestroyStart += MoveOff; 
        _destroyer.OnCombinationDestroyEnd += MoveOn;
        FindObjectOfType<TopLineChecker>().OnGameFinish+=MoveOff;
        FindObjectOfType<UIActivator>().OnGameContinue+=MoveOn;
    }

    private void OnDisable(){
        FindObjectOfType<TopLineChecker>().OnGameFinish-=MoveOff;
        FindObjectOfType<UIActivator>().OnGameContinue-=MoveOn;
        _destroyer.OnCombinationDestroyStart -= MoveOff; 
        _destroyer.OnCombinationDestroyEnd -= MoveOn;
    }

    private void Update()
    {
        if(canMove){
            _rigidbody.velocity = Vector2.down * SpeedOfFigure;
        }else{
            _rigidbody.velocity = Vector2.zero;
        }
    }

    private void ChangeSpeed(float newSpeed){
        SpeedOfFigure = newSpeed;
    }

    private void MoveOn(){
        canMove = true;
    }

    private void MoveOff(){
        canMove = false;
    }
}
