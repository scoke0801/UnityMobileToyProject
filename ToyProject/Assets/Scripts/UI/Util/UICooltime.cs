using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UICooltime : MonoBehaviour
{ 
    private float _elapsedTime;
    public float CoolTime { get; set; }

    private Image _image;

    public event Action OnClick;

    private void Awake()
    {
        TryGetComponent<Image>(out _image); 
    }
    private void OnEnable()
    {
        Init();
    }

    private void Init()
    { 
        _elapsedTime = 0.0f;
        _image.fillAmount = 0.0f;
    }
    void Update()
    {
        float ratio = GetRatio();

        if( ratio < 0.01f)
        {
            Init(); 
            this.enabled = false;
            return;
        }

        _image.fillAmount = ratio;
        _elapsedTime += Time.deltaTime;
    }

    private float GetRatio()
    {
        return ( Define.DASH_COOLTIME - _elapsedTime ) / Define.DASH_COOLTIME;
    }
}
