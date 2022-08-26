﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ResourceManager
{
	public Dictionary<string, Sprite> _sprites = new Dictionary<string, Sprite>(); 

	public void Init()
	{
	}

	public T Load<T>(string path) where T : Object
	{
		if (typeof(T) == typeof(Sprite))
		{
			if (_sprites.TryGetValue(path, out Sprite sprite))
				return sprite as T;

			Sprite sp = Resources.Load<Sprite>(path);
			_sprites.Add(path, sp);
			return sp as T;
		} 

		return Resources.Load<T>(path);
	}

	public GameObject Instantiate(string path, Transform parent = null)
	{
		GameObject prefab = Load<GameObject>($"Prefabs/{path}");
		if (prefab == null)
		{
			Debug.Log($"Failed to load prefab : {path}");
			return null;
		}

		return Instantiate(prefab, parent);
	}

	public GameObject Instantiate(GameObject prefab, Transform parent = null)
	{
		GameObject gameObject = Object.Instantiate(prefab, parent);
		gameObject.name = prefab.name;
		return gameObject;
	}

	public void Destroy(GameObject gameObject)
	{
		if (gameObject == null)
			return;

		Object.Destroy(gameObject);
	}
}