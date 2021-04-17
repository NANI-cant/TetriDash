using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAbility : MonoBehaviour
{
    [SerializeField] private Transform _rotationPoint;
    [SerializeField] private float timeBetweenRotations;
    private float remainingTimeToRotate;

    private void Start(){
        remainingTimeToRotate = timeBetweenRotations;
    }

    private void FixedUpdate(){
        if(remainingTimeToRotate <= 0){
            Rotate();
            remainingTimeToRotate = timeBetweenRotations;
        }else{
            remainingTimeToRotate-=Time.deltaTime;
        }
    }

    private void Rotate(){
        _rotationPoint.Rotate(new Vector3(0,0,-90f));
    }
}
