﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureLifetime : MonoBehaviour
{
    public float speedOfFigure;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -Time.deltaTime * speedOfFigure, 0); 
    }
}
