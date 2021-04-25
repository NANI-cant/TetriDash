using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class TeleportAbility : MonoBehaviour
{
    public float minTimeToTeleport = 3f;
    public float maxTimeToTeleport = 6f;
    private Collider2D _collider;
    private float remainigTimeToTeleport;
    private float xTeleport;
    private Transform leftSide;
    private Transform rightSide;
    private bool isTeleported = false;

    private void Start(){
        _collider = GetComponent<Collider2D>();
        remainigTimeToTeleport = Random.Range(minTimeToTeleport,maxTimeToTeleport);
        leftSide = GameObject.FindGameObjectWithTag("LeftLimit").transform;
        rightSide = GameObject.FindGameObjectWithTag("RightLimit").transform;
    }

    private void FixedUpdate(){
        if(remainigTimeToTeleport <= 0 && !isTeleported){
            TryToTeleport();
        }
        else{
            remainigTimeToTeleport-=Time.deltaTime;
        }
    }

    private void TryToTeleport(){
        do{
            float maxLeftTranslate = leftSide.position.x-transform.position.x;
            float maxRightTranslate = rightSide.position.x-transform.position.x;
            xTeleport = Random.Range(maxLeftTranslate,maxRightTranslate);
        } while (!isAreaFree());
        transform.Translate(new Vector3(xTeleport,0,0));
        isTeleported = true;
    }

    private bool isAreaFree(){
        RaycastHit2D[] boxResult;
        boxResult = Physics2D.BoxCastAll(_collider.bounds.center + new Vector3(xTeleport,0,0),_collider.bounds.size,0,new Vector2(0,0));
        if(boxResult.Length>1){
            return false;
        }else if(boxResult.Length==1 && boxResult[0].collider == _collider || boxResult.Length==0){
            return true;
        } else{
            return false;
        }
    }
} 