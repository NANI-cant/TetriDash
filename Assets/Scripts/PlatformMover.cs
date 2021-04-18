using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform leftPoint;
    [SerializeField] private Transform rightPoint;
    private Transform _transform;
    [Range(-1, 1)]
    private int movingDirection;
    readonly private float accuracity = 0.0005f;


    private void Start(){
        _transform = GetComponent<Transform>();
        movingDirection = 1;
    }

    private void FixedUpdate(){
        _transform.Translate(Vector2.right*movingDirection*speed*Time.deltaTime);
        if(Mathf.Abs(_transform.position.x - leftPoint.position.x)<=accuracity || Mathf.Abs(_transform.position.x - rightPoint.position.x)<=accuracity || Input.GetButtonDown("Fire1")){
            ChangeMovingDirection();
        }
    }

    private void ChangeMovingDirection(){
        movingDirection*=-1;
    }
}
