using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class Constants
{
    public const float MONSTER_ATTACK_COOLTILE = 1.5f;
}

public class MonsterAttack : MonoBehaviour
{
    [SerializeField]
    private Status status;
    private GameObject toCreatePrefab;

    private List<GameObject> projectiles = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        toCreatePrefab = Resources.Load<GameObject>("Prefabs/TempProjectile");
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

        GameObject newProjectile = Instantiate(toCreatePrefab, shootPos, Quaternion.Euler(0, 0, 0));
        projectiles.Add(newProjectile);


        Destroy(newProjectile, 5.0f);

        Debug.Log("Created Projectile!!!");

        return;
    }
    private void OnTriggerEnter(Collider other)
    {  
        if ( other.gameObject.name == "Chicken(Clone)")
        {
            DoAttack(other);
        }
        else if (other.gameObject.name == "Conder(Clone)")
        {
            DoAttack(other);
        }
    }
     
}
