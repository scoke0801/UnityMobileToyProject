using System.Collections;
using UnityEngine;
public class Interceptor : Projectile
{   
    public void Init()
    {
        status = new Status();
        status.speed = 10.0f;
        status.damage = 100000.0f;

        status.attackCoolTime = 0.0f;
        actType = PROJECTILE_ACT_TYPE.PROJECTILE_ACT_TYPE_TRACKING;
    }
    
    new public void Update()
    {
        status.UpdateAttackCoolTime();
        if (status.attackCoolTime <= 0.0f)
        {
        }
        if (actor != null)
        {
            Debug.Log("DoMove!!!!!");
            actor.DoMove(this);
        }
    }

    public void FindNewTarget(Collider target)
    {
        Debug.Log("FindNewTarget" + target.gameObject.name);
        actor = ProjectileActor.GetProjectileActor(actType, Shooter, target.gameObject, this.gameObject.transform.position);
        this.gameObject.SetActive(true);
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

        actor = null;
        status.attackCoolTime = 5.0f;

        // ObjectManager.instance.ReturnObject(OBJECT_TYPE.OBJ_PROJECTILE, this.gameObject);
    }
} 