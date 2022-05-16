using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProjectile : MonoBehaviour
{
    // 파일에서 읽어올 수 있도록 수정하면 좋지 않을까
    float lifeTime = 3.0f;

    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0.0f)
        {
            lifeTime = 3.0f;
            Debug.Log("Return Projectile Obj");
            ObjectManager.instance.ReturnObject(OBJECT_TYPE.OBJ_PROJECTILE, this.gameObject );
        }
    }
}
