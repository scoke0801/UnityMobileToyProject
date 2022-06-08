using UnityEditor;
using System.Collections.Generic;
using UnityEngine;

public class BudyAtomAttack : BudyAttack
{ 
    [SerializeField] private GameObject atomPrefab;

    List<GameObject> atoms;
    public BudyAtomAttack(Budy budy, int nAtomCount)
        : base(budy)
    {
        float speed = 5;
        float radius = 1;
        float baseAngle = 360.0f / nAtomCount;
        GameObject newObjectPrefab = Resources.Load("Prefabs/Atomball") as GameObject;
        for (int i = 0; i < nAtomCount; ++i)
        {
            float angle = baseAngle * i;  
            GameObject newObject = MonoBehaviour.Instantiate<GameObject>(newObjectPrefab);
            newObject.transform.position = budy.gameObject.transform.position;
            TargetFollow script = newObject.AddComponent<TargetFollow>() as TargetFollow;
            script.SetTarget(budy.gameObject, radius, speed, angle * Mathf.Deg2Rad); 
        }
    }
      
    override public void Update()
    { 
    }

    public override void DoAttack(Collider target)
    {
    }

    void Attack()
    { 
    }
}