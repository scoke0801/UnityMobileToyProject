using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    enum State
    { 
        Idle, Trace, Attack, Die
    }

    State state;
    GameObject target;
     
    Status status;
    OBJECT_TYPE objType;
    // Start is called before the first frame update
    void Start()
    {
        state = State.Trace;
        
        target = GameManager.instance.GetPlayer();

        status = new Status();
        status.speed = 5.0f;
        status.hp = 10;

        objType = OBJECT_TYPE.OBJ_TYPE_MAX;
        if (gameObject.name.Contains("Condor(Clone)"))
        {
            objType = OBJECT_TYPE.OBJ_MONSTER_CONDER;
        }
        else if (gameObject.name.Contains("Chicken(Clone)"))
        {
            objType = OBJECT_TYPE.OBJ_MONSTER_CHICKEN;
        }
        else
        {
            Debug.LogError("Can't find target name" + gameObject.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if( state == State.Trace )
        {
            Vector3 vecToTarget = target.transform.position - transform.position;
            vecToTarget.y = target.transform.position.y;
               
            Quaternion rotation = Quaternion.LookRotation( vecToTarget );
            transform.rotation = rotation;

            transform.position += vecToTarget.normalized * status.speed * Time.deltaTime;

            float minDist = 3.0f;
            if ( minDist > Vector3.Magnitude(vecToTarget))
            {  
                GameManager.instance.RefreshWaveCount(gameObject);
                ObjectManager.instance.ReturnObject(objType, gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("TempProjectile(Clone)"))
        {
            GameManager.instance.RefreshWaveCount(gameObject);
            ObjectManager.instance.ReturnObject(objType, gameObject);
        }

    }
}
