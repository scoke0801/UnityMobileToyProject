using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // 파일에서 읽어올 수 있도록 수정하면 좋지 않을까
    float lifeTime = 3.0f;
    float speed = 10.0f;

    Vector3 direction;

    GameObject shooter;
    GameObject target;

    PROJECTILE_ACT_TYPE actType = PROJECTILE_ACT_TYPE.PROJECTILE_ACT_TYPE_LINEAR;

    // Start is called before the first frame update
    void Start()
    {
        lifeTime = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        switch (actType)
        {
            case PROJECTILE_ACT_TYPE.PROJECTILE_ACT_TYPE_LINEAR:
                {
                    DoLinearMove();
                } break;
            case PROJECTILE_ACT_TYPE.PROJECTILE_ACT_TYPE_PARABOLA:
                {
                    DoParabolaMove();
                } break;
            case PROJECTILE_ACT_TYPE.PROJECTILE_ACT_TYPE_VERTICAL_WAVE:
                {
                    DoVerticalWaveMove();
                } break;
            case PROJECTILE_ACT_TYPE.PROJECTILE_ACT_TYPE_HORIZONTAL_WAVE:
                {
                    DoHorizontalWaveMove();
                } break;
            case PROJECTILE_ACT_TYPE.PROJECTILE_ACT_TYPE_TRACKING:
                {
                    DoTrackingMove();
                } break;
        }

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

    void DoParabolaMove()
    {

    }
    void DoHorizontalWaveMove()
    {

    }
    void DoVerticalWaveMove()
    { 
    
    }
    void DoTrackingMove()
    { 
    }
}
