using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportAbility : MonoBehaviour
{
    [SerializeField] private float timeBetweenTeleports;
    private Collider2D[] allColliders;
    private Collider2D leftLimit;
    private Collider2D rightLimit;
    private float remainigTimeToTeleport;

    private void Start(){
        allColliders = GetComponents<Collider2D>();
        remainigTimeToTeleport = timeBetweenTeleports;
    }

    private void FixedUpdate(){
        if(remainigTimeToTeleport <= 0){
            FindPlaceToTeleport();
            remainigTimeToTeleport = timeBetweenTeleports;
        }
        else{
            remainigTimeToTeleport-=Time.deltaTime;
        }
    }

    private void FindPlaceToTeleport(){

    }

    private void TeleportMe(){

    }
}
