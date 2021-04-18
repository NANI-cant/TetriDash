using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerFigures : MonoBehaviour
{
    //public float figurePosition = transform.position.y;
    public GameObject[] templates;
    private GameObject randomFigure;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
    }
  

    private IEnumerator Spawner()
    {
        for(int i = 0; i < 100; i++)
        {
            randomFigure = templates[Random.Range(0, templates.Length)];
            Instantiate(randomFigure, new Vector3(Random.Range(-7,7), transform.position.y, 0), Quaternion.identity);
            yield return new WaitForSeconds(5);
        }
       
    }
}
