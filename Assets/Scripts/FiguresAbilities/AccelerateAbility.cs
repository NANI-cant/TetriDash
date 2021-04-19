using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FigureMover))]
public class AccelerateAbility : MonoBehaviour
{
    [SerializeField] private float acceleration;
    [SerializeField] private float minTimeToAcceleration;
    [SerializeField] private float maxTimeToAcceleration;
    private Transform _transform;
    private Bounds _bounds;
    private FigureMover _figureMover;
    private float remainingTimeToAcceleration;
    private bool isAccelerate = false;

    private void Start(){
        _transform = transform;
        _figureMover = GetComponent<FigureMover>();
        remainingTimeToAcceleration = Random.Range(minTimeToAcceleration,maxTimeToAcceleration);
    }

    private void FixedUpdate(){
        if(!isAccelerate){
            if(remainingTimeToAcceleration<=0){
                if(CheckIsWayFree()){
                    Accelerate();
                }
            }else{
                remainingTimeToAcceleration-=Time.deltaTime;
            }
        }
    }
    
    private void Accelerate(){
        _figureMover.SpeedOfFigure+=acceleration;
        isAccelerate = true;
    }

    private bool CheckIsWayFree(){
         _bounds = new Bounds();
        for(int i=0;i<_transform.childCount;i++){
            Bounds currentChildBounds = new Bounds(_transform.GetChild(i).transform.position,Vector2.one);
            _bounds.Encapsulate(currentChildBounds);
        }
        RaycastHit2D[] hitResults;
        hitResults = Physics2D.BoxCastAll(_bounds.center,_bounds.size,0,new Vector2(0,-1));
        foreach (RaycastHit2D hitResult in hitResults){
            if(hitResult.transform.gameObject.GetComponent<FigureMover>()!=null){
                return false;
            }
        }
        return true;
    }
}
