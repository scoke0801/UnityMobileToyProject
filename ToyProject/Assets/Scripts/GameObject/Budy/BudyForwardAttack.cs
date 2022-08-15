using System.Collections;
using UnityEngine;
  
public class BudyForwardAttack : BudyAttack
{
    public BudyForwardAttack(Budy budy)
        : base(budy)
    { 
    } 

    override public void Update()
    { 
        status.attackCoolTime = status.attackCoolTime - Time.deltaTime;
        if (status.attackCoolTime <= 0.0f)
        {
            Attack();
            status.attackCoolTime = Constants.BUDY_FORWARD_ATTACK_COOLTILE;
        } 
    }

    public override void DoAttack(Collider target)
    { 
    }

    void Attack()
    { 
        Vector3 shootPos = budy.transform.position;
        shootPos.y += 0.5f;

        Vector3 dir = budy.transform.forward;

        GameObject newProjectile = ObjectManager.instance.GetObject(OBJECT_TYPE.OBJ_PROJECTILE);
        if (newProjectile)
        {
            newProjectile.GetComponent<Projectile>().Shoot(PROJECTILE_ACT_TYPE.PROJECTILE_ACT_TYPE_LINEAR, budy.gameObject, dir, shootPos);
        }

        newProjectile = ObjectManager.instance.GetObject(OBJECT_TYPE.OBJ_PROJECTILE);
        if (newProjectile)
        {
            newProjectile.GetComponent<Projectile>().Shoot(PROJECTILE_ACT_TYPE.PROJECTILE_ACT_TYPE_PARABOLA, budy.gameObject, Quaternion.Euler(0, -30, 0) * dir, shootPos);
        }

        newProjectile = ObjectManager.instance.GetObject(OBJECT_TYPE.OBJ_PROJECTILE);
        if (newProjectile)
        {
            newProjectile.GetComponent<Projectile>().Shoot(PROJECTILE_ACT_TYPE.PROJECTILE_ACT_TYPE_VERTICAL_WAVE, budy.gameObject, Quaternion.Euler(0, 30, 0) * dir, shootPos);
        }

        Debug.Log("Created Projectile!!!");
    }
} 