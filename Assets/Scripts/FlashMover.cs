using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FlashMover : MonoBehaviour
{
    [SerializeField] private AudioClip sound;
    private AudioSource _audioSource;
    readonly private float speed = 126f;
    private Transform _transform;

    private void Start(){
        _transform = transform;
        Invoke(nameof(Disable),1/3f);
        _transform.position = new Vector2(-21,_transform.position.y);
        _audioSource = GetComponent<AudioSource>();
        _audioSource.pitch = Random.Range(0.8f,1.2f);
        _audioSource.PlayOneShot(sound);
    }

    private void Update(){
        _transform.Translate(Vector2.right*speed*Time.deltaTime,Space.World);
    }

    private void Disable(){
        Destroy(gameObject);
    }
}
