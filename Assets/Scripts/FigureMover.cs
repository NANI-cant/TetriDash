using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureMover : MonoBehaviour
{
    public float SpeedOfFigure;
    private Transform _transform;
    // Start is called before the first frame update
    void Start()
    {
        _transform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        _transform.Translate(Vector2.down * SpeedOfFigure * Time.deltaTime); 
    }
}
