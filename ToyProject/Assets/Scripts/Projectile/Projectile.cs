using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // ���Ͽ��� �о�� �� �ֵ��� �����ϸ� ���� ������
    float lifeTime = 3.0f;

    Status status;

    Vector3 direction;

    GameObject shooter; 

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
        transform.Rotate(status.speed, status.speed, status.speed); 
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

    public void Shoot(PROJECTILE_ACT_TYPE actType, GameObject shooter, GameObject target, Vector3 shootPos)
    {
        this.shooter = shooter;
        this.transform.position = shootPos;

        lifeTime = 3.0f;

        actor = ProjectileActor.GetProjectileActor(actType, shooter, target, shootPos);
        this.gameObject.SetActive(true);
    }
    public void Shoot(PROJECTILE_ACT_TYPE actType, GameObject shooter, Vector3 direction, Vector3 shootPos)
    {
        this.shooter = shooter;
        this.transform.position = shootPos;

        lifeTime = 3.0f;

        actor = ProjectileActor.GetProjectileActor(actType, shooter, direction, shootPos);
        this.gameObject.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == shooter)
        {
            return;
        }
        if ( collision.gameObject ==  GameManager.instance.GetPlayerObject() )
        {
            return;
        } 
        ObjectManager.instance.ReturnObject(OBJECT_TYPE.OBJ_PROJECTILE, this.gameObject);
    }

    void DoLinearMove()
    {
    } 
}
