using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SquaresLander : MonoBehaviour
{

    public UnityAction OnSquaresLand;
    public void Land(float bottomY){
        RaycastHit2D[] hitResult;
        hitResult = Physics2D.BoxCastAll(new Vector2(0,bottomY),new Vector2(40,1),0,new Vector2(0,1));
        for(int i=0;i<hitResult.Length;i++){
            if(hitResult[i].collider.GetComponent<CombinationFinder>()!=null){
                hitResult[i].collider.transform.Translate(new Vector3(0,-3,0));
            }
        }

    }
}
