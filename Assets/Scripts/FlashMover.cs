using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashMover : MonoBehaviour
{
    readonly private float speed = 126f;
    private Transform _transform;

    private void Start(){
        _transform = transform;
        Invoke(nameof(Disable),1/3f);
        _transform.position = new Vector2(-21,_transform.position.y);
    }

    private void Update(){

        _transform.Translate(Vector2.right*speed*Time.deltaTime,Space.World);
    }

    private void Disable(){
        Destroy(gameObject);
    }
}
