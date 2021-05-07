using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonChanger : MonoBehaviour
{
    private GameInformer _informer;
    [SerializeField] private Image _image;
    [SerializeField] private Sprite start;
    [SerializeField] private Sprite restart;

    private void Start(){
        _informer = GameInformer.Singleton;
        if(_informer.IsFirstEnter){
            _image.sprite = start;
        }else{
            _image.sprite = restart;
        }
    }
}
