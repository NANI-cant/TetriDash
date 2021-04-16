using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportAbility : MonoBehaviour
{
    [SerializeField] private float timeBetweenTeleports;
    private Collider2D _collider;
    private Bounds _bounds;
    private float remainigTimeToTeleport;

    private void Start(){
        _bounds = new Bounds(Vector3.zero,Vector3.zero);
        for(int i=0;i<transform.childCount;i++){
            Bounds currentChildBounds = new Bounds(transform.GetChild(i).transform.position,Vector2.one);
            _bounds.Encapsulate(currentChildBounds);
        }
        _collider = GetComponent<Collider2D>();
        remainigTimeToTeleport = timeBetweenTeleports;
    }

    private void FixedUpdate(){
        if(remainigTimeToTeleport <= 0){
            TryToTeleport();
            remainigTimeToTeleport = timeBetweenTeleports;
        }
        else{
            remainigTimeToTeleport-=Time.deltaTime;
        }
    }

    private void TryToTeleport(){

    }
}