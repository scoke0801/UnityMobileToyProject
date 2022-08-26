﻿using System.Collections;
using UnityEngine;
 
public class BaseScene : MonoBehaviour
{
    public Define.Scene SceneType = Define.Scene.None;

    protected bool _init = false; 
    void Start()
    {
        Init();
    } 
    protected virtual bool Init()
    {
        if (_init)
        {
            return false;
        }

        _init = true;
        GameObject gameObject = GameObject.Find("EventSystem");
        if (gameObject == null)
        {
            Managers.Resource.Instantiate("UI/EventSystem").name = "@EventSystem";
        }

        return true;
    }

    public virtual void Clear() { }
} 