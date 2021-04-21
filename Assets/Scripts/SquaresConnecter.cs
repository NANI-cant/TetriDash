using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquaresConnecter : MonoBehaviour
{
    private Transform _platform;
    private bool isPlatform;
    [SerializeField] private GameObject connectedSquare;

    private void Awake(){
        _platform = FindObjectOfType<PlatformMover>().gameObject.transform;
        isPlatform = GetComponent<PlatformMover>()!=null;
    }

    private void Update(){
        RaycastHit2D[] hitResults1;
        RaycastHit2D[] hitResults2;
        RaycastHit2D[] hitResults3;
        RaycastHit2D[] hitResults4;

        if(isPlatform){
            hitResults1 = Physics2D.RaycastAll(new Vector2(transform.position.x - 1f,transform.position.y + 0.25f),new Vector2(0,1),0.01f);
            hitResults2 = Physics2D.RaycastAll(new Vector2(transform.position.x + 0f,transform.position.y + 0.25f),new Vector2(0,1),0.01f);
            hitResults3 = Physics2D.RaycastAll(new Vector2(transform.position.x + 1f,transform.position.y + 0.25f),new Vector2(0,1),0.01f);
            hitResults4 = null;
        }else{
            hitResults1 = Physics2D.RaycastAll(new Vector2(transform.position.x + 0f,transform.position.y + 0.5f),new Vector2(0,1),0.01f);
            hitResults2 = Physics2D.RaycastAll(new Vector2(transform.position.x - 0.5f,transform.position.y + 0f),new Vector2(-1,0),0.01f);
            hitResults3 = Physics2D.RaycastAll(new Vector2(transform.position.x + 0.5f,transform.position.y + 0f),new Vector2(1,0),0.01f);
            hitResults4 = Physics2D.RaycastAll(new Vector2(transform.position.x + 0f,transform.position.y - 0.5f),new Vector2(0,-1),0.01f);
        }

        //rewrite this please
        foreach (RaycastHit2D hitResult in hitResults1){
            if(hitResult.collider.gameObject.GetComponent<SpriteRenderer>()!=null && hitResult.collider.gameObject.GetComponent<SquaresConnecter>()==null){
                ConnectFigure(hitResult.collider.gameObject);
            }
        }

        foreach (RaycastHit2D hitResult in hitResults2){
            if(hitResult.collider.gameObject.GetComponent<SpriteRenderer>()!=null && hitResult.collider.gameObject.GetComponent<SquaresConnecter>()==null){
                ConnectFigure(hitResult.collider.gameObject);
            }
        }

        foreach (RaycastHit2D hitResult in hitResults3){
            if(hitResult.collider.gameObject.GetComponent<SpriteRenderer>()!=null && hitResult.collider.gameObject.GetComponent<SquaresConnecter>()==null){
                ConnectFigure(hitResult.collider.gameObject);
            }
        }

        if(hitResults4!=null){
            foreach (RaycastHit2D hitResult in hitResults4){
                if(hitResult.collider.gameObject.GetComponent<SpriteRenderer>()!=null && hitResult.collider.gameObject.GetComponent<SquaresConnecter>()==null){
                    ConnectFigure(hitResult.collider.gameObject);
                }
            }
        }
    }

    private void ConnectFigure(GameObject currentFigureSquare){
        Color currentColor = currentFigureSquare.GetComponent<SpriteRenderer>().color;
        currentFigureSquare.transform.parent = null;
        Destroy(currentFigureSquare);
        GameObject currentSquare = Instantiate(connectedSquare,currentFigureSquare.transform.position,Quaternion.identity, _platform);
        Vector3 roundedPosition = currentSquare.transform.localPosition;
        roundedPosition.x = Mathf.RoundToInt(roundedPosition.x);
        roundedPosition.y = Mathf.RoundToInt(roundedPosition.y);
        currentSquare.transform.localPosition = roundedPosition;
        currentSquare.GetComponent<SpriteRenderer>().color = currentColor;
    }
}
