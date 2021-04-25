using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TopLineChecker : MonoBehaviour
{
    public UnityAction OnGameFinish;

    private void OnTriggerEnter2D(Collider2D other){
        if(other.GetComponent<CombinationFinder>()!=null || other.GetComponent<PlatformMover>()!=null){
            Debug.Log("Finish");
            OnGameFinish?.Invoke();
        }
    }
}
