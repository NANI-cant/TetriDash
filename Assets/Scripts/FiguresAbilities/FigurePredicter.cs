using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigurePredicter : MonoBehaviour
{
    [SerializeField] private GameObject _predictSquare;
    [SerializeField] private LayerMask _layer;
    [SerializeField] private float minShowDistance = 4f;
    [SerializeField] private float maxShowDistance = 15f;
    private float showKoef;
    private Transform _transform;
    private Transform[] allPredicts;

    private void Awake(){
        _transform = transform;
        Color currentColor = GetComponentInChildren<SpriteRenderer>().color;
        currentColor.a = 0f;
        _predictSquare.GetComponentInChildren<SpriteRenderer>().color = currentColor;
        allPredicts = new Transform[_transform.childCount];
        for(int i=0;i<_transform.childCount;i++){
            GameObject currentPredict = Instantiate(_predictSquare,new Vector3(-100,-100,0),Quaternion.identity);
            allPredicts[i] = currentPredict.transform;
        }
        showKoef = (maxShowDistance-minShowDistance)/0.15f;
    }

    private void OnDisable(){
        for(int i=0;i<_transform.childCount;i++){
            Destroy(allPredicts[i].gameObject);
        }
    }
    
    private void FixedUpdate(){
        float[] raysDistances = new float[_transform.childCount];
        Transform[] childsTransforms = new Transform[_transform.childCount];

        for(int i=0;i<_transform.childCount;i++){
            childsTransforms[i] = _transform.GetChild(i).transform;
        }

        for(int i=0;i<_transform.childCount;i++){
            RaycastHit2D hitResult;
            hitResult = Physics2D.BoxCast(childsTransforms[i].position,new Vector2(0.95f,1),0, Vector2.down,40,_layer);
            if(hitResult.collider!=null)
                raysDistances[i] = hitResult.distance;
            else
                raysDistances[i] = 100;
        }

        float minDistance = Mathf.Min(raysDistances);
        ChangeColor(minDistance);
        for(int i=0;i<_transform.childCount;i++){
            Vector3 newPosition = childsTransforms[i].position;
            newPosition.y -= minDistance;
            allPredicts[i].position = newPosition;
        }
    }

    private void ChangeColor(float distance){
        float currentSquareAlpha;
        float currentCornerAlpha;
        if(distance>maxShowDistance){
            currentSquareAlpha = 0;
            currentCornerAlpha = 0;
        }else if(distance<minShowDistance){
            currentSquareAlpha = 0.15f;
            currentCornerAlpha = 0.60f;
        }else{
            currentSquareAlpha = 0.15f*(maxShowDistance-distance)/(maxShowDistance-minShowDistance);
            currentCornerAlpha = 0.60f*(maxShowDistance-distance)/(maxShowDistance-minShowDistance);
        }

        for(int i=0;i<_transform.childCount;i++){
            Color currentColor = allPredicts[i].GetComponentInChildren<SpriteRenderer>().color;
            currentColor.a = currentSquareAlpha;
            allPredicts[i].GetComponentInChildren<SpriteRenderer>().color = currentColor;
            currentColor =  allPredicts[i].GetChild(0).GetComponentInChildren<SpriteRenderer>().color;
            currentColor.a = currentCornerAlpha;
            allPredicts[i].GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().color = currentColor;
        }
    }
}
