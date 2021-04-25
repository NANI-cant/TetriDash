using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CombinationFinder : MonoBehaviour
{
    private SquaresConnecter _connecter;
    private CombinationDestroyer _destroyer;
    private SquaresLander _lander;

    private void Awake(){
        GameObject _platform = GameObject.FindObjectOfType<PlatformMover>().gameObject;
        _connecter = _platform.GetComponent<SquaresConnecter>();
        _connecter.OnSquareConnect += FindCombination;
        _lander = _platform.GetComponent<SquaresLander>();
        _lander.OnSquaresLand +=FindCombination;
        _destroyer = _platform.GetComponent<CombinationDestroyer>();
    }

    private void OnDisable(){
        _connecter.OnSquareConnect -= FindCombination;
        _lander.OnSquaresLand -=FindCombination;
    }

    private void FindCombination(){
        RaycastHit2D[] hitResults;
        hitResults = Physics2D.BoxCastAll(transform.position,Vector2.one*1.5f,0,Vector2.zero,8);
        if(hitResults.Length == 10){
            Debug.Log("Find in x = " + transform.localPosition.x.ToString() + " y = " + transform.localPosition.y.ToString());                     
            _destroyer.DestroyCombination(transform.position.y);
        }else if(hitResults.Length>10){
            Debug.Log("Error in x = " + transform.localPosition.x.ToString() + " y = " + transform.localPosition.y.ToString());
        }
    }
}
