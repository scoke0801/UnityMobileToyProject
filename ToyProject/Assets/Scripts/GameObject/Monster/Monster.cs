using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public OBJECT_TYPE objType { get; set; }

    private AudioSource audioSource;
    private Animator animator;
    private Rigidbody monsterRigidboy;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        monsterRigidboy = GetComponent<Rigidbody>();
    } 
     
    protected override void OnEnable()
    {
        base.OnEnable();
        
        state = State.Trace;

        target = Managers.Game.Player;

        status = new Status();
        status.speed = 5.0f;
        status.hp = 10; 

        StartCoroutine(FindTarget());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if( isDead ) { return; }

        if (state == State.Trace)
        {
            Vector3 moveDist = vecToTarget.normalized * status.speed * Time.fixedDeltaTime;

            monsterRigidboy.MovePosition(monsterRigidboy.position + moveDist);

            float minDist = 3.0f;
            if (minDist > Vector3.Magnitude(vecToTarget))
            {
                Die();
            }
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
        Die();
        //base.OnDamage(damage, hitPos, hitNormal);  
    }
    public override void Die()
    {
        if( isDead ) { return; }

        base.Die();

        // audioSource.PlayOneShot();
        animator.SetBool("Die", true);

        StartCoroutine(ReturnObject());
    }
    private IEnumerator ReturnObject()
    {
        // 1.8초 동안 잠시 처리를 대기
        yield return new WaitForSeconds(1.8f);

        ((GameScene)(Managers.Scene.CurrentScene)).RefreshWaveCount(gameObject);
        Managers.Pool.Push(gameObject.GetComponent<Poolable>()); 
    }
}
