using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class Constants
{
    public const float MONSTER_ATTACK_COOLTILE = 0.1f;
}

public class MonsterAttack : MonoBehaviour
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
        status.attackCoolTime = Mathf.Max(status.attackCoolTime - Time.deltaTime, 0.0f);
    }

    void DoAttack(Collider target)
    {
        if ( status.attackCoolTime > 0.0f)
        {
            // 아직 쿨타임이 남아있는 경우
            Debug.Log(" status.attackCoolTime > 0.0f ");
            return;
        }

        status.attackCoolTime += Constants.MONSTER_ATTACK_COOLTILE;

        Vector3 targetPos = target.gameObject.transform.position;
        Vector3 shootPos = transform.position;
        shootPos.y += 1.5f;
         
        GameObject newProjectile = ObjectManager.instance.GetObject(OBJECT_TYPE.OBJ_PROJECTILE); 
        newProjectile.GetComponent<Projectile>().Shoot( this.gameObject, target.gameObject, shootPos);
          
        Debug.Log("Created Projectile!!!");

        return;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if ( other.gameObject.name == "Chicken(Clone)")
        {
            DoAttack(other);
        }
        else if (other.gameObject.name == "Condor(Clone)")
        {
            DoAttack(other);
        }
    }
     
}
