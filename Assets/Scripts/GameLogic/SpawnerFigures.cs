﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerFigures : MonoBehaviour
{
    [SerializeField] private GameObject[] templates;
    [SerializeField] private float timeBetweenSpawns;
    [SerializeField] private float spawnDelay;
    [SerializeField] private Transform leftSide;
    [SerializeField] private Transform rightSide;
    private Settings _settings;
    private bool canSpawn = true;
    private Coroutine spawning = null;

    private void Start()
    {
        FindObjectOfType<TopLineChecker>().OnGameFinish += StopSpawn;
        FindObjectOfType<UIActivator>().OnGameContinue += StartSpawn;
        _settings = FindObjectOfType<Settings>();
        _settings.OnSpawnTimeChange += ChangeTimeToSpawn;
        timeBetweenSpawns = _settings.GetSpawnTime();
        Invoke(nameof(StartSpawn), spawnDelay);
        //StartSpawn();
    }

    private IEnumerator Spawner()
    {
        while (canSpawn)
        {
            float randomX = Random.Range(leftSide.InverseTransformPoint(transform.position).x, rightSide.InverseTransformPoint(transform.position).x);
            GameObject currentFigure = templates[Random.Range(0, templates.Length)];
            int randomRotateKoef = Random.Range(0, 4);
            Instantiate(currentFigure, new Vector3(randomX, transform.position.y, 0), Quaternion.Euler(0, 0, -90 * randomRotateKoef));
            currentFigure.transform.position = new Vector2(randomX, transform.position.y);
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }

    public void ChangePosition(Transform figureTransform)
    {
        figureTransform.position = transform.position;
        float randomX = Random.Range(leftSide.InverseTransformPoint(transform.position).x, rightSide.InverseTransformPoint(transform.position).x);
        figureTransform.position = new Vector2(randomX, figureTransform.position.y);
    }

    private void ChangeTimeToSpawn(float newTime)
    {
        timeBetweenSpawns = newTime;
    }

    private void StopSpawn()
    {
        canSpawn = false;
        StopCoroutine(spawning);
    }

    private void StartSpawn()
    {
        canSpawn = true;
        spawning = StartCoroutine(Spawner());
    }
}
