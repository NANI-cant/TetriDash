using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class SquaresConnecter : MonoBehaviour
{
    [SerializeField] private GameObject connectedSquare;
    [SerializeField] private AudioClip sound;
    private Transform _platform;
    private bool isPlatform;
    public UnityAction OnSquareConnect;
    private AudioSource _audioSource;
    
    private void Awake(){
        _platform = FindObjectOfType<PlatformMover>().gameObject.transform;
        isPlatform = GetComponent<PlatformMover>()!=null;
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.GetComponent<FigureMover>()!=null){
            ConnectFigure(other.gameObject);
        }
    }

    private void ConnectFigure(GameObject currentFigure){
        Vector3[] squaresPositions = new Vector3[currentFigure.transform.childCount];
        for(int i=0;i<squaresPositions.Length;i++){
            squaresPositions[i] = currentFigure.transform.GetChild(i).transform.position;
        }
        Color currentColor = currentFigure.GetComponentInChildren<SpriteRenderer>().color;
        Destroy(currentFigure);
        for(int i=0;i<squaresPositions.Length;i++){
            GameObject currentSquare = Instantiate(connectedSquare,squaresPositions[i],Quaternion.identity,_platform);
            Vector3 roundedPosition = currentSquare.transform.localPosition;
            roundedPosition.x = Mathf.RoundToInt(roundedPosition.x);
            roundedPosition.y = Mathf.RoundToInt(roundedPosition.y);
            currentSquare.transform.localPosition = roundedPosition;
            currentSquare.GetComponent<SpriteRenderer>().color = currentColor;
        }
        _audioSource.pitch=Random.Range(0.8f,1.2f);
        _audioSource.PlayOneShot(sound);
        OnSquareConnect?.Invoke();
    }
}