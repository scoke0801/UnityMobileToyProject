using UnityEditor;
using UnityEngine;

public class Status 
{
    public float speed;
    public float hp;
    public float attackCoolTime;
    public float damage;

    public Status() { }
    public Status(float speed, float hp, float attackCoolTime, float damage)
    {
       this.speed = speed;
       this.hp = hp;
       this.attackCoolTime = attackCoolTime;
       this.damage = damage;
    }
}

public class ProjectileStatus
{ }

public class MonsterStatus
{ }