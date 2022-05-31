using System.Collections;
using UnityEngine;
  
public class BudyForwardAttack : BudyAct
{  
    public override void DoAttack(Collider target)
    {
        if (status.attackCoolTime > 0.0f)
        {
            // 아직 쿨타임이 남아있는 경우
            Debug.Log(" status.attackCoolTime > 0.0f ");
            return;
        }

        Vector3 targetPos = target.gameObject.transform.position;
        Vector3 shootPos = transform.position;
        shootPos.y += 0.5f;

        Vector3 dir = this.transform.forward;

        GameObject newProjectile = ObjectManager.instance.GetObject(OBJECT_TYPE.OBJ_PROJECTILE);
        if (newProjectile)
        {
            newProjectile.GetComponent<Projectile>().Shoot(PROJECTILE_ACT_TYPE.PROJECTILE_ACT_TYPE_LINEAR, this.gameObject, dir, shootPos);
        }

        newProjectile = ObjectManager.instance.GetObject(OBJECT_TYPE.OBJ_PROJECTILE);
        if (newProjectile)
        {
            newProjectile.GetComponent<Projectile>().Shoot(PROJECTILE_ACT_TYPE.PROJECTILE_ACT_TYPE_PARABOLA, this.gameObject, Quaternion.Euler(0, -30, 0) * dir, shootPos);
        }

        newProjectile = ObjectManager.instance.GetObject(OBJECT_TYPE.OBJ_PROJECTILE);
        if (newProjectile)
        {
            newProjectile.GetComponent<Projectile>().Shoot(PROJECTILE_ACT_TYPE.PROJECTILE_ACT_TYPE_VERTICAL_WAVE, this.gameObject, Quaternion.Euler(0, 30, 0) * dir, shootPos);
        }

        Debug.Log("Created Projectile!!!");

        return;
    }
} 