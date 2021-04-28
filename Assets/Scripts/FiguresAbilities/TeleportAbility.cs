using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class TeleportAbility : MonoBehaviour
{
    public float MinTimeToTeleport = 3f;
    public float MaxTimeToTeleport = 6f;
    private bool canTeleport = true;
    private float maxLeftTranslate;
    private float maxRightTranslate;
    private Collider2D _collider;
    private float remainigTimeToTeleport;
    private Transform leftSide;
    private Transform rightSide;
    private bool isTeleported = false;
    private CombinationDestroyer _destroyer;

    private void Start(){
        _collider = GetComponent<Collider2D>();
        remainigTimeToTeleport = Random.Range(MinTimeToTeleport,MaxTimeToTeleport);
        leftSide = GameObject.FindGameObjectWithTag("LeftLimit").transform;
        rightSide = GameObject.FindGameObjectWithTag("RightLimit").transform;
        maxLeftTranslate = leftSide.position.x-transform.position.x;
        maxRightTranslate = rightSide.position.x-transform.position.x;
        _destroyer = FindObjectOfType<CombinationDestroyer>();
        _destroyer.OnCombinationDestroyStart += TeleportOff; 
        _destroyer.OnCombinationDestroyEnd += TeleportOn;
        FindObjectOfType<TopLineChecker>().OnGameFinish+=TeleportOff;
    }

    private void OnDisable(){
        FindObjectOfType<TopLineChecker>().OnGameFinish-=TeleportOff;
        _destroyer.OnCombinationDestroyStart -= TeleportOff; 
        _destroyer.OnCombinationDestroyEnd -= TeleportOn;
    }

    private void FixedUpdate(){
        if(!isTeleported && canTeleport){
            if(remainigTimeToTeleport <= 0){
                TryToTeleport();
            }
            else{
                remainigTimeToTeleport-=Time.deltaTime;
            }
        }
    }

    private void TryToTeleport(){
        float xTeleport = 0;
        do{
            maxLeftTranslate = leftSide.position.x-transform.position.x;
            maxRightTranslate = rightSide.position.x-transform.position.x;
            xTeleport = Random.Range(maxLeftTranslate,maxRightTranslate);
        } while (!isAreaFree(xTeleport));
        transform.Translate(new Vector3(xTeleport,0f,0f),Space.World);
        isTeleported = true;
    }

    private bool isAreaFree(float xTeleport){
        RaycastHit2D[] boxResult;
        boxResult = Physics2D.BoxCastAll(_collider.bounds.center + new Vector3(xTeleport,0,0),_collider.bounds.size,0,Vector2.zero);
        if(boxResult.Length>1){
            return false;
        }else if(boxResult.Length==1 && boxResult[0].collider == _collider || boxResult.Length==0){
            return true;
        } else{
            return false;
        }
    }

    private void TeleportOn(){
        canTeleport = true;
    }

    private void TeleportOff(){
        canTeleport = false;
    }
} 