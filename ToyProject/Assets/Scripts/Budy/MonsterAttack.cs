using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class Constants
{
    public const float MONSTER_ATTACK_COOLTILE = 1.5f;
}

public class MonsterAttack : MonoBehaviour
{
    [SerializeField]
    private Status status;

    // Start is called before the first frame update
    void Start()
    {
        status = new Status();
    }

    // Update is called once per frame
    void Update()
    {
        status.attackCoolTime = Mathf.Max(status.attackCoolTime - Time.deltaTime, 0.0f);
    }

    void DoAttack()
    {
        if ( status.attackCoolTime > 0.0f)
        {
            // 아직 쿨타임이 남아있는 경우
            return;
        }

        status.attackCoolTime += Constants.MONSTER_ATTACK_COOLTILE;

        // To do
        //
        return;
    }
    private void OnTriggerEnter(Collider other)
    {  
        if ( other.gameObject.name == "Chicken(Clone)")
        {
            DoAttack();
        }
        else if (other.gameObject.name == "Conder(Clone)")
        {
            DoAttack();
        }
    }
     
}
