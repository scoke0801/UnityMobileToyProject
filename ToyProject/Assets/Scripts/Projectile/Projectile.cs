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
    PROJECTILE_ACT_TYPE actType = PROJECTILE_ACT_TYPE.PROJECTILE_ACT_TYPE_LINEAR;
    ProjectileActor actor;

    private OBJECT_TYPE objectType; 

    // Start is called before the first frame update
    protected void Start()
    {
        status = new Status();
        status.speed = 10.0f;
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
            Debug.Log("Return Projectile Obj");
            ObjectManager.instance.ReturnObject(objectType, this.gameObject);
        }
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
        this.gameObject.SetActive(true);
    }

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == shooter)
        {
            return;
        }
        if ( collision.gameObject ==  GameManager.instance.GetPlayerObject() )
        {
            return;
        }
        if (collision.gameObject.tag == "Projectile")
        {
            return;
        }

        ObjectManager.instance.ReturnObject(OBJECT_TYPE.OBJ_PROJECTILE, this.gameObject);
    } 
}
