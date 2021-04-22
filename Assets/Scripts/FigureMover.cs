using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureMover : MonoBehaviour
{
    public float SpeedOfFigure;
    private Transform _transform;
    private Rigidbody2D _rigidbody;
    private void Start()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //_transform.Translate(Vector2.down * SpeedOfFigure * Time.deltaTime,Space.World); 
        _rigidbody.velocity = Vector2.down * SpeedOfFigure;
    }
}
