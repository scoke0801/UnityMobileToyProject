using System.Collections;
using UnityEngine;
public class Interceptor : Projectile
{ 
    TargetFollow targetFollow;
    public void SetTargetFollow(TargetFollow _targetFollow)
    {
        if (_targetFollow) { this.targetFollow = _targetFollow;  }
    }

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

    public void FindNewTarget(Collider target)
    { 
    
    }

    new void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == GameManager.instance.GetPlayerObject())
        {
            return;
        }

        if (collision.gameObject == Shooter )
        {
            return;
        }

        if (collision.gameObject.tag == "Projectile")
        {
            return;
        }
        if (collision.gameObject.tag == "Obstacle")
        {
            return;
        }

        Debug.Log("Interceptor!!!");
        
        // ObjectManager.instance.ReturnObject(OBJECT_TYPE.OBJ_PROJECTILE, this.gameObject);
    }
} 