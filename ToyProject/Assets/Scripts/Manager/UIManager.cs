using System.Collections;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class UIManager
{
    int _order = -20;

    Stack<UIPopup> _popupStack = new Stack<UIPopup>();
	public UIScene _sceneUI { get; private set; }

	public GameObject Root
	{
		get
		{
			GameObject root = GameObject.Find("@UIRoot");
			if (root == null)
			{
				root = new GameObject { name = "@UIRoot" };
			}
			return root;
		}
	}

	public void SetCanvas(GameObject gameObject, bool sort = true)
	{
		Canvas canvas = Util.GetOrAddComponent<Canvas>(gameObject);
		canvas.renderMode = RenderMode.ScreenSpaceOverlay;
		canvas.overrideSorting = true;

		if (sort)
		{
			canvas.sortingOrder = _order;
			_order++;
		}
		else
		{
			canvas.sortingOrder = 0;
		}
	}

	public T MakeSubItem<T>(Transform parent = null, string name = null) where T : UIBase
	{
		if (string.IsNullOrEmpty(name))
			name = typeof(T).Name;

		GameObject prefab = Managers.Resource.Load<GameObject>($"Prefabs/UI/SubItem/{name}");

		GameObject gameObject = Managers.Resource.Instantiate(prefab);
		if (parent != null)
		{
			gameObject.transform.SetParent(parent);
		}

		gameObject.transform.localScale = Vector3.one;
		gameObject.transform.localPosition = prefab.transform.position;

		return Util.GetOrAddComponent<T>(gameObject);
	}

	public T ShowSceneUI<T>(string name = null) where T : UIScene
	{
		if (string.IsNullOrEmpty(name))
		{
			name = typeof(T).Name;
		}

		GameObject gameObject = Managers.Resource.Instantiate($"UI/Scene/{name}");
		T sceneUI = Util.GetOrAddComponent<T>(gameObject);
		_sceneUI = sceneUI;

		gameObject.transform.SetParent(Root.transform);

		return sceneUI;
	}

	public T PushPopupUI<T>(string name = null, Transform parent = null) where T : UIPopup
	{
		if (string.IsNullOrEmpty(name))
		{
			name = typeof(T).Name;
		}

		GameObject prefab = Managers.Resource.Load<GameObject>($"Prefabs/UI/Popup/{name}");

		GameObject gameObject = Managers.Resource.Instantiate($"UI/Popup/{name}");
		T popup = Util.GetOrAddComponent<T>(gameObject);
		_popupStack.Push(popup);

		if (parent != null)
		{
			gameObject.transform.SetParent(parent);
		}
		else if (_sceneUI != null)
		{
			gameObject.transform.SetParent(_sceneUI.transform);

		}
		else
		{
			gameObject.transform.SetParent(Root.transform);
		}

		gameObject.transform.localScale = Vector3.one;
		gameObject.transform.localPosition = prefab.transform.position;

		Debug.Log("ShowPopupUI");
		return popup;
	}

	public T FindPopup<T>() where T : UIPopup
	{
		return _popupStack.Where(x => x.GetType() == typeof(T)).FirstOrDefault() as T;
	}

	public T PeekPopupUI<T>() where T : UIPopup
	{
		if (_popupStack.Count == 0)
		{
			return null;
		}

		return _popupStack.Peek() as T;
	}

	public void ClosePopupUI(UIPopup popup)
	{
		if (_popupStack.Count == 0)
		{
			return;
		}

		if (_popupStack.Peek() != popup)
		{
			Debug.Log("Close Popup Failed!");
			return;
		}

		ClosePopupUI();
	}
	public void ShowPopupUI<T>() where T : UIPopup
	{
		if (_popupStack.Count == 0)
		{
			return;
		}
		T popup = FindPopup<T>();

		if (popup != null)
		{
			// 이미 존재하는 팝업인 경우 
			ShowPopupUI(popup);
		}
        else // popup == null
        {
			// 존재하지 않는 팝업인 경우, 새롭게 생성
			PushPopupUI<T>();
        }
	}

	public void ShowPopupUI(UIPopup popup)
	{
		popup.gameObject.SetActive(true);
	}
	public void HidePopupUI<T>() where T : UIPopup
	{
		if (_popupStack.Count == 0)
		{
			return;
		}
		T popup = FindPopup<T>();

        if (popup != null) 
		{
			HidePopupUI(popup);
		}
	}

	public void HidePopupUI(UIPopup popup)
	{
		popup.gameObject.SetActive(false);
	}
	public void ClosePopupUI()
	{
		if (_popupStack.Count == 0)
		{
			return;
		}

		UIPopup popup = _popupStack.Pop();
		Managers.Resource.Destroy(popup.gameObject);
		popup = null;
		_order--;
	}

	public void CloseAllPopupUI()
	{
		while (_popupStack.Count > 0)
		{
			ClosePopupUI();
		}
	}

	public void Clear()
	{
		CloseAllPopupUI();
		_sceneUI = null;
	}
}