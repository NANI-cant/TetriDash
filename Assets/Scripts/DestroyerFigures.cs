using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyerFigures : MonoBehaviour
{
    [SerializeField] private bool isSideLimit;
    [SerializeField] private SpawnerFigures _spawnerFigures;

    public UnityAction OnFigureDestroy;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<FigureMover>()!=null){
            if(isSideLimit){
                //Destroy(other.gameObject);
                //Debug.Log("FigureOutOfRange");
                _spawnerFigures.ChangePosition(other.gameObject.transform);
            }else{
                Destroy(other.gameObject);
                OnFigureDestroy?.Invoke();
            }
        }
    }
}
