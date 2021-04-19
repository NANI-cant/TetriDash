using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformLifter : MonoBehaviour
{
    [SerializeField] private DestroyerFigures _deadLine;

    private void Start(){
        _deadLine.OnFigureDestroy+=LiftPlatform;
    }

    private void LiftPlatform(){
        Debug.Log("PlatformLiftActivate");
    }
}
