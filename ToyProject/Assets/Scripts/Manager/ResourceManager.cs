using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ResourceManager
{
	public Dictionary<string, Sprite> _sprites = new Dictionary<string, Sprite>(); 

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
		else if (typeof(T) == typeof(GameObject))
		{
			string name = path;
			int index = name.LastIndexOf('/'); // '/' 뒤의 이름 추출. 
			if (index >= 0)
				name = name.Substring(index + 1); // 이게 바로 프리팹의 이름.

			GameObject go = Managers.Pool.GetOriginal(name);
			if (go != null)
				return go as T;
		}

		return Resources.Load<T>(path);
	}

	public GameObject Instantiate(string path, Transform parent = null)
	{
		GameObject prefab = Load<GameObject>($"Prefabs/{path}");
		if (prefab == null)
		{
			DebugWrapper.Log($"Failed to load prefab : {path}");
			return null;
		}

		if (prefab.GetComponent<Poolable>() != null)
			return Managers.Pool.Pop(prefab, parent).gameObject;

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

		Managers.Pool.Push(gameObject);
		return;
	}
}