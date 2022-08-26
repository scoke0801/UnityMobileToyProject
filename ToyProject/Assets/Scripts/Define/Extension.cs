using UnityEditor;
using UnityEngine;
using System;

public static class Extension
{
	public static T GetOrAddComponent<T>(this GameObject go) where T : UnityEngine.Component
	{
		return Util.GetOrAddComponent<T>(go);
	}

	public static void BindEvent(this GameObject go, Action action, Define.UIEvent type = Define.UIEvent.Click)
	{
		UIBase.BindEvent(go, action, type);
	}
}