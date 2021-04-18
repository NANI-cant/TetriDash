using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureMover : MonoBehaviour
{
    public float SpeedOfFigure;
    private Transform _transform;
    private void Start()
    {
        _transform = transform;
    }

    private void Update()
    {
        _transform.Translate(Vector2.down * SpeedOfFigure * Time.deltaTime); 
    }
}
