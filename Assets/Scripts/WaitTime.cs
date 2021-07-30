using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaitTime : MonoBehaviour
{
    [SerializeField] private float time = 0f;
    [SerializeField] private UnityEvent OnTimeWait;

    private void Start()
    {
        Invoke(nameof(DoAction), time);
    }

    private void DoAction()
    {
        OnTimeWait?.Invoke();
    }
}
