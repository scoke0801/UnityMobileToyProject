using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // 파일에서 읽어올 수 있도록 수정하면 좋지 않을까
    public float lifeTime = 3.0f;

    public Status status;

    Vector3 direction;
     
    private GameObject shooter; 
    public GameObject Shooter
    {
        get { return shooter; }
        set { if (value) shooter = value; }
    }
    protected PROJECTILE_ACT_TYPE actType = PROJECTILE_ACT_TYPE.PROJECTILE_ACT_TYPE_LINEAR;
    protected ProjectileActor actor;

    private OBJECT_TYPE objectType;
    private TrailRenderer _trailRenderer;
     
    protected void Awake()
    {
        status = new Status();
        status.speed = 40.0f;
        status.damage = 100000.0f; 
        status.lifeTime = lifeTime;
        _trailRenderer = GetComponent<TrailRenderer>();
    }

    private void OnEnable()
    {
        if (status == null)
        {
            status = new Status();
        }

        status.speed = 40.0f;
        status.damage = 100000.0f;
        status.lifeTime = lifeTime; 
    }
      
    // Update is called once per frame
    protected void Update()
    {
        transform.Rotate(status.speed, status.speed, status.speed); 
        if(actor != null)
        {
            actor.DoMove(this);
        }
        UpdateLifeTime();
    }

    void UpdateLifeTime()
    {
        status.UpdateLifeTime();
        if (status.lifeTime <= 0.0f)
        { 
            Managers.Pool.Push(gameObject); 
        }
    }

    public bool GetCanAttack()
    {
        if(status == null) { return false; }
        return status.attackCoolTime <= 0.0f;
    }
    // 추후 수정 필요, 플레이어 직접 공격할 때 사용하기 위함.
    public void Swing(GameObject shooter, Vector3 direction, Vector3 shootPos)
    {
        this.shooter = shooter;
        this.transform.position = shootPos;
        objectType = OBJECT_TYPE.OBJ_METAL_PROJECTILE;

        lifeTime = 3.0f;
        actor = ProjectileActor.GetProjectileActor(actType, shooter, direction, shootPos);
        this.gameObject.SetActive(true);
    }

    public void Shoot(PROJECTILE_ACT_TYPE actType, GameObject shooter, GameObject target, Vector3 shootPos)
    {
        this.shooter = shooter;
        this.transform.position = shootPos;
        objectType = OBJECT_TYPE.OBJ_PROJECTILE;

        lifeTime = 3.0f;

        actor = ProjectileActor.GetProjectileActor(actType, shooter, target, shootPos);
        this.gameObject.SetActive(true);
    }
    public void Shoot(PROJECTILE_ACT_TYPE actType, GameObject shooter, Vector3 direction, Vector3 shootPos)
    {
        this.shooter = shooter;
        this.transform.position = shootPos;
        objectType = OBJECT_TYPE.OBJ_PROJECTILE;

        lifeTime = 3.0f;

        actor = ProjectileActor.GetProjectileActor(actType, shooter, direction, shootPos);
        _trailRenderer.Clear();
        this.gameObject.SetActive(true);
    }

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == shooter)
        {
            return;
        }
        if ( collision.gameObject == Managers.Game.Player )
        {
            return;
        }
        if (collision.gameObject.CompareTag( "Projectile" ))
        {
            return;
        }
        if (collision.gameObject.CompareTag("Budy"))
        {
            return;
        } 
        if( collision.gameObject.CompareTag("Obstacle"))
        {
            return;
        }

        Managers.Pool.Push(collision.gameObject); 
    } 
}
