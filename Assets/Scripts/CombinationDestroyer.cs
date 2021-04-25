using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CombinationDestroyer : MonoBehaviour
{
    private SquaresLander _lander;
    public UnityAction OnCombinationDestroy;

    private void Start(){
        _lander = GetComponent<SquaresLander>();
    }

    public void DestroyCombination(float yCoordinate){
        RaycastHit2D[] hitResults;
        hitResults = Physics2D.BoxCastAll(new Vector2(0,yCoordinate),new Vector2(40,1.5f),0,Vector2.zero);
        for(int i=0;i<hitResults.Length;i++){
            if(hitResults[i].collider.GetComponent<CombinationFinder>()!=null){
                Destroy(hitResults[i].collider.gameObject);
            }
        }
        OnCombinationDestroy?.Invoke();
        _lander.Land(yCoordinate - 1);
    }
}
