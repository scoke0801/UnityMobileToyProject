using System;
using System.Collections;
using System.Collections.Generic; 
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIBase : MonoBehaviour
{
    protected Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>();

    protected bool _init = false;

    public virtual bool Init()
    {
        if (_init)
        {
            return false;
        }
        return _init = true;
    }

    void Start()
    {
        Init();
    }

    #region Bind
    // Type 값은 enum값으로 사용
    protected void Bind<T>(Type type) where T : UnityEngine.Object
    {
        string[] names = Enum.GetNames(type);
        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];
        _objects.Add(typeof(T), objects);

        for (int index = 0; index < names.Length; ++index)
        {
            if (typeof(T) == typeof(GameObject))
            {
                objects[index] = Util.FindChild(gameObject, names[index], true);
            }
            else // typeof(T) != typeof(GameObject)
            {
                objects[index] = Util.FindChild<T>(gameObject, names[index], true);
            }

            if (objects[index] == null)
            {
                DebugWrapper.Log($"Failed To Bind({names[index]})");
            }
        }
    } 
    protected void BindObject(Type type) { Bind<GameObject>(type); } 
    protected void BindImage(Type type) { Bind<Image>(type); }
    protected void BindText(Type type) { Bind<TextMeshProUGUI>(type); }
    protected void BindButton(Type type) { Bind<Button>(type); }
    public static void BindEvent(GameObject gameObject, Action action, Define.UIEvent type = Define.UIEvent.Click)
    {
        UIEventHandler evt = Util.GetOrAddComponent<UIEventHandler>(gameObject);

        switch (type)
        {
            case Define.UIEvent.Click:
                evt._onClickHandler -= action;
                evt._onClickHandler += action;
                break;
            case Define.UIEvent.Pressed:
                evt._onPressedHandler -= action;
                evt._onPressedHandler += action;
                break;
            case Define.UIEvent.PointerDown:
                evt._onPointerDownHandler -= action;
                evt._onPointerDownHandler += action;
                break;
            case Define.UIEvent.PointerUp:
                evt._onPointerUpHandler -= action;
                evt._onPointerUpHandler += action;
                break;
        }
    }
    #endregion

    #region get
    protected T Get<T>(int idx) where T : UnityEngine.Object
    {
        UnityEngine.Object[] objects = null;
        if (_objects.TryGetValue(typeof(T), out objects) == false)
            return null;

        return objects[idx] as T;
    }

    public GameObject GetObject(int idx) { return Get<GameObject>(idx); } 
    public TextMeshProUGUI GetText(int idx) { return Get<TextMeshProUGUI>(idx); }
    public Button GetButton(int idx) { return Get<Button>(idx); }
    public Image GetImage(int idx) { return Get<Image>(idx); }
    #endregion
}