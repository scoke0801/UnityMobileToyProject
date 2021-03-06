using System.Collections;
using UnityEngine;
public class Interceptor : Projectile
{
    GameObject target;
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

            if (Shooter == target)
            {
                Vector3 vecToTarget = target.transform.position - transform.position;
                vecToTarget.y = target.transform.position.y;  
                if ( 1.5f > Vector3.Magnitude(vecToTarget))
                {
                    this.gameObject.SetActive(false);
                    actor = null; 
                }
            }
        }
    }

    public void FindNewTarget(GameObject target)
    {
        this.target = target; 
        actor = ProjectileActor.GetProjectileActor(actType, Shooter, target, this.gameObject.transform.position);
        this.gameObject.SetActive(true);
    }

    new void OnCollisionEnter(Collision collision)
    { 
        if (collision.gameObject == GameManager.instance.GetPlayerObject())
        {
            return;
        }
        if (collision.gameObject.tag == "Budy") 
        {
            if (Shooter == target)
            {
                this.gameObject.SetActive(false);
                actor = null;
            }
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

        FindNewTarget(Shooter);
        status.attackCoolTime = 5.0f;

        // ObjectManager.instance.ReturnObject(OBJECT_TYPE.OBJ_PROJECTILE, this.gameObject);
    }
} 