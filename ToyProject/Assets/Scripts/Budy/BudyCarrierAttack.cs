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
         
        GameObject newObjectPrefab = Resources.Load("Prefabs/Inteceptor") as GameObject;
        for (int i = 0; i < nInterceptorCount; ++i)
        { 
            GameObject newObject = MonoBehaviour.Instantiate<GameObject>(newObjectPrefab);
            newObject.transform.position = budy.gameObject.transform.position;
            Interceptor script = newObject.AddComponent<Interceptor>() as Interceptor;
            script.Shooter = budy.gameObject;
            script.Init();
            newObject.SetActive(false);

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
    override public void DoAttack(Collider target)
    {
        for (int i = 0; i < interceptors.Count; ++i)
        {
            Interceptor script = interceptors[i].GetComponent<Interceptor>();
            if (script && !script.gameObject.activeSelf )
            {
                script.FindNewTarget(target);
                break;
            }
        }
    }
} 