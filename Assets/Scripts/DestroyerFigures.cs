﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerFigures : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<FigureMover>()!=null){
            Destroy(other.gameObject);
        }
    }
}
