using System.Collections;
using UnityEngine;
using System;

public class LivingObject : MonoBehaviour, IDamageable
{
    public float originHP;
    public float HP { get; protected set; }
    public bool isDead { get; protected set; }
    public event Action onDie;

    protected virtual void OnEnable()
    {
        isDead = false;
        HP = originHP;
    } 

    virtual public void OnDamage(float damage, Vector3 hitPos, Vector3 hitNormal)
    {
        HP -= damage;

        if (HP <= 0 && !isDead)
        {
            Die();
        }
    }

    virtual public void RestoreHP( float addHP )
    {
        if (isDead) { return; }

        HP = Math.Max( HP + addHP, originHP );
    }

    virtual public void Die()
    {
        if (onDie != null)
        {
            onDie();
        }

        isDead = true;
    }
} 