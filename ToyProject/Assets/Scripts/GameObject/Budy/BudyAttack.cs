using UnityEngine;

public class BudyAttack
{
    [SerializeField]
    protected Status status;

    protected GameObject toCreatePrefab;

    [SerializeField]
    protected Define.PROJECTILE_ACT_TYPE projectileActType;

    protected Budy budy;

    public BudyAttack(Budy budy)
    {
        this.budy = budy;
        
        status = new Status();
        projectileActType = Define.PROJECTILE_ACT_TYPE.PROJECTILE_ACT_TYPE_LINEAR;
    }
      
    virtual public void Update()
    {
        // ���¿� ���� �ൿ�ϰ� ������ ��... 
        if (status.attackHoldingTime > 0.0f)
        {
            status.UpdateAttackHoldingTime(); 
            if (status.attackHoldingTime <= 0.0f)
            {
                status.attackCoolTime += Constants.BUDY_BASE_ATTACK_COOLTILE; 
            }
        }
        else if (status.attackCoolTime > 0.0f)
        {
            status.UpdateAttackCoolTime(); 
            if (status.attackHoldingTime <= 0.0f)
            {
                status.attackHoldingTime += Constants.BUDY_ATTACK_HOLDINGTIME;
            }
        }
    }

    virtual public void DoAttack(Collider target)
    {
        if (status.attackCoolTime > 0.0f)
        {
            // ���� ��Ÿ���� �����ִ� ���
            DebugWrapper.Log("status.attackCoolTime > 0.0f");
            return;
        }

        Vector3 targetPos = target.gameObject.transform.position;
        Vector3 shootPos = budy.transform.position;
        shootPos.y += 0.5f;

        Vector3 dir = budy.transform.forward;
          
        GameObject newProjectile = Managers.Prefab.GetPrefab(Define.PrefabTypeName.Projectile);
        if (newProjectile)
        {
            newProjectile.GetComponent<Projectile>().Shoot(Define.PROJECTILE_ACT_TYPE.PROJECTILE_ACT_TYPE_TRACKING, budy.gameObject, target.gameObject, shootPos);
        }
         
        return;
    }
}
