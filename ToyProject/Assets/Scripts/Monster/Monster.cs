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

    float speed;

    // Start is called before the first frame update
    void Start()
    {
        state = State.Trace;
        
        target = GameManager.instance.GetPlayer();

        speed = 5.0f;
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

            transform.position += vecToTarget.normalized * speed * Time.deltaTime;

            float minDist = 3.0f;
            if ( minDist > Vector3.Magnitude(vecToTarget))
            { 
                Destroy( gameObject );
            }
        }
    }
}
