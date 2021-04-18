using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerFigures : MonoBehaviour
{
    [SerializeField] private GameObject[] templates;
    [SerializeField] private float timeBetweenSpawns;
    private GameObject currentFigure;

    void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        for(int i = 0; i < 100; i++)
        {
            int randomX = Random.Range(-8,9);
            currentFigure = templates[Random.Range(0, templates.Length)];
            Instantiate(currentFigure, new Vector3(randomX, transform.position.y, 0), Quaternion.identity);
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
       
    }
}
