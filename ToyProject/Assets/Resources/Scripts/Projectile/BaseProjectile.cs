using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProjectile : MonoBehaviour
{
    // 파일에서 읽어올 수 있도록 수정하면 좋지 않을까
    float lifeTime = 3.0f;
    float speed = 10.0f;

    Vector3 direction;
     
    // Start is called before the first frame update
    void Start()
    {
        lifeTime = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = transform.position + direction * speed * Time.deltaTime;
         
        transform.position = newPos;

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

    public void Shoot(GameObject target, Vector3 shootPos)
    {
        Vector3 targetPosition = target.transform.position;
        transform.position = shootPos;

        direction = (targetPosition - shootPos).normalized; 

        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(0, 10, 0); 

        this.gameObject.SetActive(true);
    } 
}
