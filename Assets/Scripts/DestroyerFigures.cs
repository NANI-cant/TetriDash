using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyerFigures : MonoBehaviour
{
    public UnityAction OnFigureDestroy;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<FigureMover>()!=null){
            Destroy(other.gameObject);
            OnFigureDestroy?.Invoke();
        }
    }
}
