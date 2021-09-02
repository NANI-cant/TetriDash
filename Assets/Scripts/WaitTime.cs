using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Events;

public class WaitTime : MonoBehaviour
{
    [SerializeField] private float time = 0f;
    [SerializeField] private UnityEvent OnTimeWait;
    [SerializeField] private VideoPlayer videoPlayer;

    private void Start()
    {
        //Invoke(nameof(DoAction), time);

        videoPlayer.Prepare();
        videoPlayer.prepareCompleted += ctx => videoPlayer.Play();
    }

    private IEnumerator Play()
    {
        while (!videoPlayer.isPrepared)
        {
            Debug.Log("Prepared " + videoPlayer.isPrepared.ToString());
            yield return new WaitForSeconds(3f);
        }
        videoPlayer.Play();
        yield return new WaitForSeconds(3f);
    }

    private void DoAction()
    {
        OnTimeWait?.Invoke();
    }
}
