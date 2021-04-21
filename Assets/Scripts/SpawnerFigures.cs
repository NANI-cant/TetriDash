using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerFigures : MonoBehaviour
{
    [SerializeField] private GameObject[] templates;
    [SerializeField] private float timeBetweenSpawns;
    [SerializeField] private Transform leftSide; 
    [SerializeField] private Transform rightSide;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        float randomX = Random.Range(leftSide.InverseTransformPoint(transform.position).x,rightSide.InverseTransformPoint(transform.position).x);
        GameObject currentFigure = templates[Random.Range(0, templates.Length)];
        int randomRotateKoef = Random.Range(0,4);
        Instantiate(currentFigure, new Vector3(randomX, transform.position.y, 0),Quaternion.Euler(0,0,-90*randomRotateKoef));
        currentFigure.transform.position = new Vector2(randomX,transform.position.y);
        yield return new WaitForSeconds(timeBetweenSpawns);
        StartCoroutine(Spawner());
    }

    public void ChangePosition(Transform figureTransform){
        figureTransform.position = transform.position;
        float randomX = Random.Range(leftSide.InverseTransformPoint(transform.position).x,rightSide.InverseTransformPoint(transform.position).x);
        figureTransform.position = new Vector2(randomX, figureTransform.position.y);
    }
}
