using UnityEngine;

public class BudyAttack
{
    [SerializeField]
    protected Status status;

    protected GameObject toCreatePrefab;

    [SerializeField]
    protected PROJECTILE_ACT_TYPE projectileActType;

    protected Budy budy;

    public BudyAttack(Budy budy)
    {
        this.budy = budy;
        
        status = new Status();
        projectileActType = PROJECTILE_ACT_TYPE.PROJECTILE_ACT_TYPE_LINEAR;
    }
      
    // Update is called once per frame
    virtual public void Update()
    {
        // 상태에 따라서 행동하게 수정할 것... 
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
            // 아직 쿨타임이 남아있는 경우
            Debug.Log(" status.attackCoolTime > 0.0f ");
            return;
        }

        Vector3 targetPos = target.gameObject.transform.position;
        Vector3 shootPos = budy.transform.position;
        shootPos.y += 0.5f;

        Vector3 dir = budy.transform.forward;
         
        GameObject newProjectile = ObjectManager.instance.GetObject(OBJECT_TYPE.OBJ_PROJECTILE);
        if (newProjectile)
        {
            newProjectile.GetComponent<Projectile>().Shoot(PROJECTILE_ACT_TYPE.PROJECTILE_ACT_TYPE_TRACKING, budy.gameObject, target.gameObject, shootPos);
        }

        Debug.Log("Created Projectile!!!");

        return;
    }
}
