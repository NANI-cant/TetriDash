using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform leftSide;
    [SerializeField] private Transform rightSide;
    private CombinationDestroyer _destroyer;
    private bool canMove = true;
    private Transform _transform;
    private Camera _camera;
    private float movingDirection = 0;
    readonly private float accuracity = 0.06f;
    private bool canMoveLeft = true;
    private bool canMoveRight = true;

    private void Start(){
        _transform = GetComponent<Transform>();
        _camera = Camera.main;
        _destroyer = FindObjectOfType<CombinationDestroyer>();
        _destroyer.OnCombinationDestroyStart += MoveOff; 
        _destroyer.OnCombinationDestroyEnd += MoveOn;
        FindObjectOfType<TopLineChecker>().OnGameFinish += MoveOff;
        FindObjectOfType<UIActivator>().OnGameContinue+=MoveOn;
    }

    private void OnDisable(){
        FindObjectOfType<TopLineChecker>().OnGameFinish -= MoveOff;
        FindObjectOfType<UIActivator>().OnGameContinue-=MoveOn;
        _destroyer.OnCombinationDestroyStart -= MoveOff; 
        _destroyer.OnCombinationDestroyEnd -= MoveOn;
    }

    private void Update(){
        if(Mathf.Abs(leftSide.position.x-transform.position.x)<accuracity){
            canMoveLeft=false;
        }else{
            canMoveLeft=true;
        }

        if(Mathf.Abs(rightSide.position.x-transform.position.x)<accuracity){
            canMoveRight=false;
        }else{
            canMoveRight=true;
        }

        Vector3 cursorPosition;
        if(Input.GetButton("Fire1")){
            cursorPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            movingDirection = cursorPosition.x/Mathf.Abs(cursorPosition.x);
            if((movingDirection>0 && canMoveRight || movingDirection<0 && canMoveLeft) && canMove){
                _transform.Translate(Vector2.right*movingDirection*speed*Time.deltaTime);
            }
        }
    }

    private void MoveOn(){
        canMove = true;
    }

    private void MoveOff(){
        canMove = false;
    }
}