using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BudyAct : MonoBehaviour
{
    [SerializeField]
    protected Status status;

    protected GameObject toCreatePrefab;

    [SerializeField]
    protected PROJECTILE_ACT_TYPE projectileActType;

    // Start is called before the first frame update
    void Start()
    {
        status = new Status();
        projectileActType = PROJECTILE_ACT_TYPE.PROJECTILE_ACT_TYPE_LINEAR;
    }

    // Update is called once per frame
    void Update()
    {
        // 상태에 따라서 행동하게 수정할 것... 
        if (status.attackHoldingTime > 0.0f)
        {
            status.attackHoldingTime = Mathf.Max(status.attackHoldingTime - Time.deltaTime, 0.0f);
            if (status.attackHoldingTime <= 0.0f)
            {
                status.attackCoolTime += Constants.BUDY_ATTACK_COOLTILE; 
            }
        }
        else if (status.attackCoolTime > 0.0f)
        {
            status.attackCoolTime = Mathf.Max(status.attackCoolTime - Time.deltaTime, 0.0f);
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
        Vector3 shootPos = transform.position;
        shootPos.y += 0.5f;

        Vector3 dir = this.transform.forward;
        
        GameObject newProjectile = ObjectManager.instance.GetObject(OBJECT_TYPE.OBJ_PROJECTILE);
        if(newProjectile)
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
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.gameObject.name == "Chicken(Clone)")
        {
            DoAttack(other);
        }
        else if (other.gameObject.name == "Condor(Clone)")
        {
            DoAttack(other);
        }
    }

    public void OnClickedBtn1()
    {
        projectileActType = PROJECTILE_ACT_TYPE.PROJECTILE_ACT_TYPE_LINEAR;
    }
    public void OnClickedBtn2()
    {
        projectileActType = PROJECTILE_ACT_TYPE.PROJECTILE_ACT_TYPE_VERTICAL_WAVE; 
    }
    public void OnClickedBtn3()
    { 
        projectileActType = PROJECTILE_ACT_TYPE.PROJECTILE_ACT_TYPE_TRACKING;
    }
}
