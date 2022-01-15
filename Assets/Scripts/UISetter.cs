using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISetter : MonoBehaviour
{
    [SerializeField] private Button LBButton;
    [SerializeField] private Button ExitGPSButton;

    private void Start(){
        LBButton.onClick.AddListener(GooglePlayServices.GPSSingleton.ShowLeaderBoard);
        ExitGPSButton.onClick.AddListener(GooglePlayServices.GPSSingleton.ExitFromGPS);
    }
}
