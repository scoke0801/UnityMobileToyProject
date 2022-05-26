using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BudyAct : MonoBehaviour
{
    [SerializeField]
    private Status status;
    private GameObject toCreatePrefab;
     
    // Start is called before the first frame update
    void Start()
    {
        status = new Status();
    }

    // Update is called once per frame
    void Update()
    {
        // ���¿� ���� �ൿ�ϰ� ������ ��... 
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

    void DoAttack(Collider target)
    {  
        if (status.attackCoolTime > 0.0f)
        {
            // ���� ��Ÿ���� �����ִ� ���
            Debug.Log(" status.attackCoolTime > 0.0f ");
            return;
        } 

        Vector3 targetPos = target.gameObject.transform.position;
        Vector3 shootPos = transform.position;
        shootPos.y += 0.5f;

        GameObject newProjectile = ObjectManager.instance.GetObject(OBJECT_TYPE.OBJ_PROJECTILE);
        newProjectile.GetComponent<Projectile>().Shoot(this.gameObject, target.gameObject, shootPos);
        newProjectile.gameObject.transform.position = shootPos;

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
}
