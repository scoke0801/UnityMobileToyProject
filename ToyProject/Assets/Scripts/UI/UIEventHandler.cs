using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIEventHandler : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
	public Action _onClickHandler = null;
	public Action _onPressedHandler = null;
	public Action _onPointerDownHandler = null;
	public Action _onPointerUpHandler = null;

	bool _pressed = false;

	private void Update()
	{
		if (_pressed)
		{
			_onPressedHandler?.Invoke();
		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		_onClickHandler?.Invoke();
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		_pressed = true;
		_onPointerDownHandler?.Invoke();
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		_pressed = false;
		_onPointerUpHandler?.Invoke();
	}
}
