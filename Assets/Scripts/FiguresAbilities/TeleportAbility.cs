using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportAbility : MonoBehaviour
{
    [SerializeField] private float timeBetweenTeleports;
    private Collider2D _collider;
    private Bounds _bounds;
    private float remainigTimeToTeleport;
    private int xTeleport;
    readonly private int maxLeftTranslate = -15;
    readonly private int maxRightTranslate = 16;

    private void Start(){
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
        _bounds = new Bounds();
        for(int i=0;i<transform.childCount;i++){
            Bounds currentChildBounds = new Bounds(transform.GetChild(i).transform.position,Vector2.one);
            _bounds.Encapsulate(currentChildBounds);
        }
        do{
            xTeleport = Random.Range(maxLeftTranslate,maxRightTranslate);
        } while (!isAreaFree());
        transform.Translate(new Vector3(xTeleport,0,0));
    }

    private bool isAreaFree(){
        RaycastHit2D[] boxResult;
        boxResult = Physics2D.BoxCastAll(_bounds.center + new Vector3(xTeleport,0,0),_bounds.size,0,new Vector2(0,0));
        if(boxResult.Length>1){
            return false;
        }else if(boxResult.Length==1 && boxResult[0].collider == _collider || boxResult.Length==0){
            return true;
        } else{
            return false;
        }
    }

    // private void OnDrawGizmos(){
    //     RaycastHit2D[] boxResult;
    //     boxResult = Physics2D.BoxCastAll(_bounds.center + new Vector3(xTeleport,0,0),_bounds.size,0,new Vector2(0,0));
    //     if(boxResult.Length>1){
    //         Gizmos.color = Color.red;
    //         Gizmos.DrawWireCube(_bounds.center + new Vector3(xTeleport,0,0),_bounds.size);
    //     }else if(boxResult.Length==1 && boxResult[0].collider == _collider || boxResult.Length==0){
    //         Gizmos.color = Color.green;
    //         Gizmos.DrawWireCube(_bounds.center + new Vector3(xTeleport,0,0),_bounds.size);
    //     }
    // }
} 