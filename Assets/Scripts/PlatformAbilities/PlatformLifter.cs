using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformLifter : MonoBehaviour
{
    [SerializeField] private DestroyerFigures _deadLine;
    [SerializeField] private float liftingSpeed = 0.35f;
    public float UnitForLiftUp = 3f;
    public float UnitForLiftDown = 1f;

    private bool canLift = true;
    private CombinationDestroyer _destroyer;
    private Transform _transform;
    private float startHeight;
    private float currentHeight;

    private void Start(){
        _deadLine.OnFigureDestroy+=LiftPlatform;
        _transform = transform;
        startHeight = currentHeight = _transform.position.y;
        FindObjectOfType<TopLineChecker>().OnGameFinish+=LiftOff;
        FindObjectOfType<UIActivator>().OnGameContinue+=LiftOn;
        _destroyer = FindObjectOfType<CombinationDestroyer>();
        _destroyer.OnCombinationDestroyStart += LiftOff;
        _destroyer.OnCombinationDestroyEnd += LiftDownPlatform;
        _destroyer.OnCombinationDestroyEnd += LiftOn;
    }

    private void OnDisable(){
        FindObjectOfType<TopLineChecker>().OnGameFinish-=LiftOff;
        FindObjectOfType<UIActivator>().OnGameContinue-=LiftOn;
        _deadLine.OnFigureDestroy-=LiftPlatform;
        _destroyer.OnCombinationDestroyEnd -= LiftDownPlatform;
    }

    private void Update(){
        if(_transform.position.y!=currentHeight && canLift){
            float distance = currentHeight - _transform.position.y;
            transform.Translate(new Vector3(0,distance,0).normalized * liftingSpeed * Time.deltaTime);
        }
    }

    private void LiftPlatform(){
        currentHeight += UnitForLiftUp;
    }

    public void LiftDownPlatform(){
        if(currentHeight > startHeight){
            currentHeight -= UnitForLiftDown;
        }
    }

    public void ImmediatlyDownToCenter(){
        if(_transform.position.y> startHeight+6f){
            currentHeight = startHeight + 6f;
            _transform.Translate(new Vector3(0,currentHeight-_transform.position.y,0));
        }
    }

    private void LiftOn(){
        canLift = true;
    }

    private void LiftOff(){
        canLift = false;
    }
}
