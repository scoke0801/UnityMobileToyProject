using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // 파일에서 읽어올 수 있도록 수정하면 좋지 않을까
    float lifeTime = 3.0f;

    Status status;

    Vector3 direction;

    GameObject shooter;
    GameObject target;
    public GameObject Target
    {
        get { return target; }
    }

    PROJECTILE_ACT_TYPE actType = PROJECTILE_ACT_TYPE.PROJECTILE_ACT_TYPE_LINEAR;
    ProjectileActor actor;

    // Start is called before the first frame update
    void Start()
    {
        lifeTime = 3.0f;
        status = new Status();
        status.speed = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        actor.DoMove(this);
        UpdateLifeTime();
    }

    void UpdateLifeTime()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0.0f)
        {
            Debug.Log("Return Projectile Obj");
            ObjectManager.instance.ReturnObject(OBJECT_TYPE.OBJ_PROJECTILE, this.gameObject);
        }
    }

    public void Shoot(GameObject shooter, GameObject target, Vector3 shootPos)
    {
        this.shooter = shooter;
        this.target = target;

        // actor = new ProjectileLinearActor(shooter, target, shootPos);
        // actor = new ProjectileVerticalWaveActor(shooter, target, shootPos);
        // actor = new ProjectileParabolaActor(shooter, target, shootPos); 
        actor = new ProjectileTrackingActor(shooter, target, shootPos);
        this.gameObject.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == shooter)
        {
            return;
        }
        if ( collision.gameObject ==  GameManager.instance.GetPlayer() )
        {
            return;
        }
        //OBJECT_TYPE objType = OBJECT_TYPE.OBJ_TYPE_MAX;
        //if (collision.gameObject.name.Contains("Condor(Clone)"))
        //{
        //    objType = OBJECT_TYPE.OBJ_MONSTER_CONDER;
        //}
        //else if (collision.gameObject.name.Contains("Chicken(Clone)"))
        //{
        //    objType = OBJECT_TYPE.OBJ_MONSTER_CHICKEN;
        //}
        //else
        //{
        //    Debug.LogError("Can't find target name" + gameObject.name);
        //}

        //if( objType != OBJECT_TYPE.OBJ_TYPE_MAX )
        //{ 
        //    GameManager.instance.RefreshWaveCount(collision.gameObject);
        //    ObjectManager.instance.ReturnObject(objType, collision.gameObject);
        //}
        ObjectManager.instance.ReturnObject(OBJECT_TYPE.OBJ_PROJECTILE, this.gameObject);
    }

    void DoLinearMove()
    {
    } 
}
