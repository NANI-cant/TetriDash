using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformLifter : MonoBehaviour
{
    [SerializeField] private DestroyerFigures _deadLine;
    [SerializeField] private float liftingSpeed = 0.3f;
    private Transform _transform;
    private float startHeight;
    private float currentHeight;

    private void Start(){
        _deadLine.OnFigureDestroy+=LiftPlatform;
        _transform = transform;
        startHeight = currentHeight = _transform.position.y;
    }

    private void FixedUpdate(){
        if(_transform.position.y!=currentHeight){
            float distance = currentHeight - _transform.position.y;
            transform.Translate(new Vector3(0,distance,0) * liftingSpeed * Time.deltaTime);
        }
    }

    private void LiftPlatform(){
        currentHeight++;
    }

    private void LiftDownPlatform(){
        if(currentHeight>startHeight){
            currentHeight--;
        }
    }
}
