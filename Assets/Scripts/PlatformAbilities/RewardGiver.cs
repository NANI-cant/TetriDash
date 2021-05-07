using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardGiver : MonoBehaviour
{
    private List<Transform> squares;

    public void Give(){
        DownPlatform();
        InitializeList();
        float maxY = FindMaxY();
        DeleteSquares(maxY);
    }

    private void DownPlatform(){
        PlatformLifter _lifter = GetComponentInParent<PlatformLifter>();
        _lifter.ImmediatlyDownToCenter();
    }

    private void InitializeList(){
        squares = new List<Transform>();
        for(int i=0;i<transform.childCount;i++){
            Transform currentChild = transform.GetChild(i);
            if(currentChild.GetComponent<CombinationFinder>()!=null){
                squares.Add(currentChild);
            }
        }
    }

    private float FindMaxY(){
        float maxY = 0;
        foreach (Transform square in squares){
            if(square.localPosition.y>maxY){
                maxY = square.localPosition.y;
            }
        }
        return maxY;
    }

    private void DeleteSquares(float maxY){
        foreach (Transform square in squares){
            if(square.localPosition.y==maxY ||square.localPosition.y==maxY-1 || square.localPosition.y==maxY-2){
                Destroy(square.gameObject);
            }
        }
    }
}
