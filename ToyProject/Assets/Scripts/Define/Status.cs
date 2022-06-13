using UnityEditor;
using UnityEngine;

public class Status 
{
    public float speed;
    public float hp;
    
    public float attackCoolTime;        // 공격 쿨타임.
    public float attackHoldingTime;     // 공격 유지 시간.

    public float damage;

    public Status() { }
    public Status(float speed, float hp, float attackCoolTime, float attackHoldingTime, float damage)
    {
        this.speed = speed;
        this.hp = hp;
        this.attackCoolTime = attackCoolTime;
        this.attackHoldingTime = attackHoldingTime;
        this.damage = damage;
    }
}
    
public class ProjectileStatus
{ }

public class MonsterStatus
{ }