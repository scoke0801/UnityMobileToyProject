using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Monster : LivingObject
{
    enum State
    { 
        Idle, Trace, Attack, Die
    }

    State _state;
    GameObject _target;
    Vector3 _vecToTarget;

    Status _status;
    
    public Define.ObjectType ObjType { get; set; }
    
    public event Action<Monster> OnDyingAnimationDone = delegate {  };

    private AudioSource _audioSource;
    private Animator _animator;
    private Rigidbody _monsterRigidboy;
    private CapsuleCollider _collider;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
        _monsterRigidboy = GetComponent<Rigidbody>();
        _collider = GetComponent<CapsuleCollider>();
    } 
     
    protected override void OnEnable()
    {
        base.OnEnable();
        
        _state = State.Trace;

        _target = Managers.Game.Player;

        _status = new Status();
        _status.speed = 5.0f;
        _status.hp = 10;
        _collider.enabled = true; 
        _monsterRigidboy.useGravity = true; 

        StartCoroutine(FindTarget());
    }
     
    void FixedUpdate()
    {
        if( _isDead ) { return; }

        if (_state == State.Trace)
        {
            Vector3 moveDist = _vecToTarget.normalized * _status.speed * Time.fixedDeltaTime;

            _monsterRigidboy.MovePosition(_monsterRigidboy.position + moveDist); 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ( collision.gameObject.CompareTag("Projectile") )
        {  
            Projectile projectile = gameObject.GetComponent<Projectile>();
            if (projectile == null) { return; }
             
            Vector3 vecNormal = gameObject.transform.position - collision.contacts[0].point; 
            OnDamage(projectile.status.damage, collision.contacts[0].point, vecNormal);
        } 
    }
     
    private IEnumerator FindTarget()
    {
        WaitForSeconds var = new WaitForSeconds(0.15f);
        while ( !_isDead )
        {
            if (_state == State.Trace && _target )
            {
                _vecToTarget = _target.transform.position - transform.position;
                _vecToTarget.y = _target.transform.position.y;

                Quaternion rotation = Quaternion.LookRotation(_vecToTarget);
                transform.rotation = rotation; 
            }
            // 0.15�� ���� ��� ó���� ���
            yield return var;
        }
    }
    override public void OnDamage(float damage, Vector3 hitPos, Vector3 hitNormal)
    {
        base.OnDamage(damage, hitPos, hitNormal);
         
        GameObject particle = Util.GetRandomParticle(Define.PrefabTypeName.PARTICLE_HIT_1, Define.PrefabTypeName.PARTICLE_HIT_4);
        particle.transform.position = hitPos;
        
        StartCoroutine(ReturnParticle(particle));
    }
    public override void Die()
    {
        if( _isDead ) { return; }

        base.Die();

        // _audioSource.PlayOneShot();
        _animator.SetBool("Die", true);
        _collider.enabled = false;
        _monsterRigidboy.useGravity = false;

        StartCoroutine(ReturnObject());
    }
    private IEnumerator ReturnObject()
    {
        // 1.8�� ���� ��� ó���� ���
        yield return new WaitForSeconds(1.8f); 
        OnDyingAnimationDone(this);
        OnDyingAnimationDone = delegate {  };
    }

    private IEnumerator ReturnParticle(GameObject particle)
    { 
        yield return new WaitForSeconds(0.5f);
        if (particle == null)
        {
            yield break;
        } 

        Managers.Pool.Push(particle);  
    }
}
