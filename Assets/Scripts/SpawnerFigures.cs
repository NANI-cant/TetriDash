using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerFigures : MonoBehaviour
{
    [SerializeField] private GameObject[] templates;
    [SerializeField] private float timeBetweenSpawns;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        int randomX = Random.Range(-8,9);
        GameObject currentFigure = templates[Random.Range(0, templates.Length)];
        Instantiate(currentFigure, new Vector3(randomX, transform.position.y, 0), Quaternion.identity);
        currentFigure.transform.position = new Vector2(randomX,transform.position.y);
        yield return new WaitForSeconds(timeBetweenSpawns);
        StartCoroutine(Spawner());
    }

    public void ChangePosition(Transform figureTransform){
        figureTransform.position = transform.position;
        int randomX = Random.Range(-8,9);
        figureTransform.position = new Vector2(randomX, figureTransform.position.y);
    }
}
