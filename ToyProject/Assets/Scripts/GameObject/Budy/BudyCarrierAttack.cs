using System.Collections;
using UnityEngine;
using System.Collections.Generic;
public class BudyCarrierAttack : BudyAttack
{
    [SerializeField] private GameObject atomPrefab;

    List<GameObject> _objects;
    List<Interceptor> _scripts;
    public BudyCarrierAttack(Budy budy, int nInterceptorCount)
        : base(budy)
    {
        _objects = new List<GameObject>(nInterceptorCount); 
        _scripts = new List<Interceptor>(nInterceptorCount);

        GameObject newObjectPrefab = Managers.Prefab.GetPrefab(Define.PrefabTypeName.INTECEPTOR);
        for (int i = 0; i < nInterceptorCount; ++i)
        { 
            GameObject newObject = MonoBehaviour.Instantiate<GameObject>(newObjectPrefab);
            newObject.transform.position = budy.gameObject.transform.position;

            Interceptor script = newObject.AddComponent<Interceptor>() as Interceptor;
            script.Shooter = budy.gameObject;
            script.Init();
            
            newObject.SetActive(false);

            _objects.Add(newObject);
            _scripts.Add(script);
        }
    }

    override public void DoAttack(Collider target)
    {
        for (int i = 0; i < _objects.Count; ++i)
        { 
            if (_scripts[i] && !_scripts[i].gameObject.activeSelf )
            {
                _scripts[i].FindNewTarget(target.gameObject); 
                _objects[i].transform.position = budy.gameObject.transform.position;
                break;
            }
        }
    }
} 