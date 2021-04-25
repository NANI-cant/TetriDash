using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationDestroyer : MonoBehaviour
{
    public void DestroyCombination(float yCoordinate){
        RaycastHit2D[] hitResults;
        hitResults = Physics2D.BoxCastAll(new Vector2(0,yCoordinate),new Vector2(40,1.5f),0,Vector2.zero);
        for(int i=0;i<hitResults.Length;i++){
            if(hitResults[i].collider.GetComponent<CombinationFinder>()!=null){
                Destroy(hitResults[i].collider.gameObject);
            }
        }
    }
}
