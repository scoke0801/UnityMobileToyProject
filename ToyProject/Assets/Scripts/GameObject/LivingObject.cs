using System.Collections;
using UnityEngine;
using System;

public class LivingObject : MonoBehaviour, IDamageable
{
    public float _originHP;
    public float _HP { get; protected set; }
    public bool _isDead { get; protected set; }
    public event Action _onDie;

    protected virtual void OnEnable()
    {
        _isDead = false;
        _HP = _originHP;
    } 

    virtual public void OnDamage(float damage, Vector3 hitPos, Vector3 hitNormal)
    {
        _HP -= damage;

        if (_HP <= 0 && !_isDead)
        {
            Die();
        }
    }

    virtual public void RestoreHP( float addHP )
    {
        if (_isDead) { return; }

        _HP = Math.Max( _HP + addHP, _originHP );
    }

    virtual public void Die()
    {
        if (_onDie != null)
        {
            _onDie();
        }

        _isDead = true;
    }
} 