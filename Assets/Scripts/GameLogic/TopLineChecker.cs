using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class TopLineChecker : MonoBehaviour
{
    [SerializeField] private AudioClip sound;
    public UnityAction OnGameFinish;
    private AudioSource _audioSource;

    private void Awake(){
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.GetComponent<CombinationFinder>()!=null || other.GetComponent<PlatformMover>()!=null){
            OnGameFinish?.Invoke();
            _audioSource.pitch = Random.Range(0.8f,1.2f);
            _audioSource.PlayOneShot(sound);
        }
    }
}
