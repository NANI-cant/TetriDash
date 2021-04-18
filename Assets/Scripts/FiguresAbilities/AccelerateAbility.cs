using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FigureLifetime))]
public class AccelerateAbility : MonoBehaviour
{
    [SerializeField] private float acceleration;
    [SerializeField] private float minTimeToAcceleration;
    [SerializeField] private float maxTimeToAcceleration;
    private FigureLifetime _figureLifeTime;
    private float remainingTimeToAcceleration;
    private bool isAccelerate = false;

    private void Start(){
        _figureLifeTime = GetComponent<FigureLifetime>();
        remainingTimeToAcceleration = Random.Range(minTimeToAcceleration,maxTimeToAcceleration);
    }

    private void FixedUpdate(){
        if(!isAccelerate){
            if(remainingTimeToAcceleration<=0){
                Accelerate();
            }else{
                remainingTimeToAcceleration-=Time.deltaTime;
            }
        }
    }
    
    private void Accelerate(){
        _figureLifeTime.speed+=acceleration;
        isAccelerate = true;
    }
}
