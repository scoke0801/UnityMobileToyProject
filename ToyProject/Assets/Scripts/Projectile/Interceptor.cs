using System.Collections;
using UnityEngine;
public class Interceptor : Projectile
{ 
    new void Start()
    {
        base.Start();
    }
     
    new public void Update()
    {
        if (status.attackCoolTime >= 0.0f)
        {
            status.UpdateAttackCoolTime();
            if (status.attackCoolTime <= 0.0f)
            {
                this.gameObject.SetActive(true);
            }
        }
    }
} 