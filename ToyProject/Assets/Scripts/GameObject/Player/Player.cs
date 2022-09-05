using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Status status;

    private int projectileShootCountAtOnce;

    public int ProjectileShootCountAtOnce
    {
        get { return projectileShootCountAtOnce; }
        set { Mathf.Min( Mathf.Max(projectileShootCountAtOnce + value, 3), Constants.MAX_PROJECTILE_SHOOT_COUNT_AT_ONCE); }
    }
    // Start is called before the first frame update
    void Start()
    {
        status = new Status();
        status.hp = 10;
        status.speed = 1;

        projectileShootCountAtOnce = 1;
    }

    // Update is called once per frame
    void Update()
    {
        status.UpdateAttackCoolTime();
        if( status.attackCoolTime < 0.0f)
        {
            status.attackCoolTime = 0.0f;
        } 
        status.attackCoolTime = Mathf.Max(status.attackCoolTime - Time.deltaTime, 0.0f); 
    }

    void Attack()
    {
        if (status.attackCoolTime > 0.0f)
        {
            // 아직 쿨타임이 남아있는 경우
            DebugWrapper.Log("Player status.attackCoolTime > 0.0f ");
            return;
        }
        Vector3 shootPos = transform.position;
        shootPos.y += 1.5f;

        Vector3 dir = transform.forward;
         
        GameObject newProjectile = Managers.Prefab.GetPrefab(Define.PrefabTypeName.Projectile);
        if (newProjectile)
        {
            newProjectile.GetComponent<Projectile>().Swing(this.gameObject, dir, shootPos); 
        }

        status.attackCoolTime = Constants.PLAYER_ATTACK_COOLTILE;
    }

    public void OnButtonClick()
    {
        Attack();
    }
}
