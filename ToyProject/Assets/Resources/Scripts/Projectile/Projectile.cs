using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // ���Ͽ��� �о�� �� �ֵ��� �����ϸ� ���� ������
    float lifeTime = 3.0f;
    float speed = 10.0f;

    Vector3 direction;

    GameObject shooter;
    GameObject target;

    PROJECTILE_ACT_TYPE actType = PROJECTILE_ACT_TYPE.PROJECTILE_ACT_TYPE_LINEAR;
    ProjectileActor actor;

    // Start is called before the first frame update
    void Start()
    {
        actor = new ProjectileLinearActor();
        lifeTime = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        actor.DoMove(this.gameObject);
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

        Vector3 targetPosition = target.transform.position;
        transform.position = shootPos;

        direction = (targetPosition - shootPos).normalized;

        this.gameObject.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == shooter)
        {
            return;
        }

        ObjectManager.instance.ReturnObject(OBJECT_TYPE.OBJ_PROJECTILE, this.gameObject);
    }

    void DoLinearMove()
    {
        Vector3 newPos = transform.position + direction * speed * Time.deltaTime;

        transform.position = newPos; 
    } 
}
