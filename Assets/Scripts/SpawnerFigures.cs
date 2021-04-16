using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerFigures : MonoBehaviour
{
    public GameObject Template;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Template);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
