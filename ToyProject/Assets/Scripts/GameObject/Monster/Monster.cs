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

    State state;
    GameObject target;
    Vector3 vecToTarget;

    Status status;
    public Define.ObjectType objType { get; set; }

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
        
        state = State.Trace;

        target = Managers.Game.Player;

        status = new Status();
        status.speed = 5.0f;
        status.hp = 10;
        _collider.enabled = true; 
        _monsterRigidboy.useGravity = true; 

        StartCoroutine(FindTarget());
    }
     
    void FixedUpdate()
    {
        if( isDead ) { return; }

        if (state == State.Trace)
        {
            Vector3 moveDist = vecToTarget.normalized * status.speed * Time.fixedDeltaTime;

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
        while ( !isDead )
        {
            if (state == State.Trace && target )
            {
                vecToTarget = target.transform.position - transform.position;
                vecToTarget.y = target.transform.position.y;

                Quaternion rotation = Quaternion.LookRotation(vecToTarget);
                transform.rotation = rotation; 
            }
            // 0.15초 동안 잠시 처리를 대기
            yield return var;
        }
    }
    override public void OnDamage(float damage, Vector3 hitPos, Vector3 hitNormal)
    {
        base.OnDamage(damage, hitPos, hitNormal);
         
        GameObject particle = Util.GetRandomParticle(Define.PrefabTypeName.ParticleHit1, Define.PrefabTypeName.ParticleHit4);
        particle.transform.position = hitPos;
        
        StartCoroutine(ReturnParticle(particle));
    }
    public override void Die()
    {
        if( isDead ) { return; }

        base.Die();

        // _audioSource.PlayOneShot();
        _animator.SetBool("Die", true);
        _collider.enabled = false;
        _monsterRigidboy.useGravity = false;

        StartCoroutine(ReturnObject());
    }
    private IEnumerator ReturnObject()
    {
        // 1.8초 동안 잠시 처리를 대기
        yield return new WaitForSeconds(1.8f); 
        ((GameScene)(Managers.Scene.CurrentScene)).RefreshWaveCount(this.gameObject); 
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
