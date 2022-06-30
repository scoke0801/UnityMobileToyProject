using System.Collections;
using UnityEngine;
using System.Collections.Generic;
public class BudyCarrierAttack : BudyAttack
{
    [SerializeField] private GameObject atomPrefab;

    List<GameObject> interceptors;
    public BudyCarrierAttack(Budy budy, int nInterceptorCount)
        : base(budy)
    {
        interceptors = new List<GameObject>(nInterceptorCount);

        float speed = 5;
        float radius = 1; 
        GameObject newObjectPrefab = Resources.Load("Prefabs/Atomball") as GameObject;
        for (int i = 0; i < nInterceptorCount; ++i)
        { 
            GameObject newObject = MonoBehaviour.Instantiate<GameObject>(newObjectPrefab);
            newObject.transform.position = budy.gameObject.transform.position;

            // Interceptor script = newObject.AddComponent<Interceptor>() as Interceptor;
            // script.SetTarget(budy.gameObject, radius, speed, angle * Mathf.Deg2Rad);

            interceptors.Add(newObject);
        }
    }

    override public void Update()
    {
        //for (int i = 0; i < interceptors.Count; ++i)
        //{
        //    if (!interceptors[i].activeSelf)
        //    {
        //        interceptors[i].GetComponent<Atomball>().Update();
        //        interceptors[i].GetComponent<TargetFollow>().Update();
        //    }
        //}
    }
} 