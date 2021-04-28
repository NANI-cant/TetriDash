using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAbility : MonoBehaviour
{
    [SerializeField] private float timeBetweenRotations;
    private CombinationDestroyer _destroyer;
    private bool canRotate = true;
    private float remainingTimeToRotate;

    private void Start(){
        remainingTimeToRotate = timeBetweenRotations;
        _destroyer = FindObjectOfType<CombinationDestroyer>();
        _destroyer.OnCombinationDestroyStart += RotateOff; 
        _destroyer.OnCombinationDestroyEnd += RotateOn;
        FindObjectOfType<TopLineChecker>().OnGameFinish+=RotateOff;
    }

    private void OnDisable(){
        FindObjectOfType<TopLineChecker>().OnGameFinish-=RotateOff;
        _destroyer.OnCombinationDestroyStart -= RotateOff; 
        _destroyer.OnCombinationDestroyEnd -= RotateOn;
    }

    private void FixedUpdate(){
        if(canRotate){
            if(remainingTimeToRotate <= 0){
                Rotate();
                remainingTimeToRotate = timeBetweenRotations;
            }else{
                remainingTimeToRotate-=Time.deltaTime;
            }
        }
    }

    private void Rotate(){
        transform.Rotate(new Vector3(0,0,-90));
    }

    private void RotateOn(){
        canRotate = true;
    }

    private void RotateOff(){
        canRotate = false;
    }
}
