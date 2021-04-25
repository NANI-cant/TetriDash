using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FigureMover))]
public class AccelerateAbility : MonoBehaviour
{
    [SerializeField] private float acceleration;
    [SerializeField] private float minTimeToAcceleration;
    [SerializeField] private float maxTimeToAcceleration;
    private Collider2D _collider;
    private FigureMover _figureMover;
    private float remainingTimeToAcceleration;
    private bool isAccelerate = false;

    private void Start(){
        _figureMover = GetComponent<FigureMover>();
        _collider = GetComponent<Collider2D>();
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
        _figureMover.SpeedOfFigure+=acceleration;
        isAccelerate = true;
    }
}
