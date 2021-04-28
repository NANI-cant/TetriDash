using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FigureMover))]
public class AccelerateAbility : MonoBehaviour
{
    [SerializeField] private float acceleration;
    [SerializeField] private float minTimeToAcceleration;
    [SerializeField] private float maxTimeToAcceleration;
    private CombinationDestroyer _destroyer;
    private bool canAccelerate = true;
    private Collider2D _collider;
    private FigureMover _figureMover;
    private float remainingTimeToAcceleration;
    private bool isAccelerate = false;

    private void Start(){
        _figureMover = GetComponent<FigureMover>();
        _collider = GetComponent<Collider2D>();
        remainingTimeToAcceleration = Random.Range(minTimeToAcceleration,maxTimeToAcceleration);
        _destroyer = FindObjectOfType<CombinationDestroyer>();
        _destroyer.OnCombinationDestroyStart += AccelerateOff; 
        _destroyer.OnCombinationDestroyEnd += AccelerateOn;
        FindObjectOfType<TopLineChecker>().OnGameFinish+=AccelerateOff;
    }

    private void OnDisable(){
        FindObjectOfType<TopLineChecker>().OnGameFinish-=AccelerateOff;
        _destroyer.OnCombinationDestroyStart -= AccelerateOff; 
        _destroyer.OnCombinationDestroyEnd -= AccelerateOn;
    }

    private void FixedUpdate(){
        if(!isAccelerate && canAccelerate){
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

    private void AccelerateOn(){
        canAccelerate = true;
    }

    private void AccelerateOff(){
        canAccelerate = false;
    }
}
