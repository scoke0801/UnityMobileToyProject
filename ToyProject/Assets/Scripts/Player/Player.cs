using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Status status;

    private int projectileShootCountAtOnce;

    public int ProjectileShootCountAtOnce
    {
        get { return projectileShootCountAtOnce; }
        set { Mathf.Min( Mathf.Max(projectileShootCountAtOnce + value, 3), Constants.MAX_PROJECTILE_SHOOT_COUNT_AT_ONCE); }
    }
    // Start is called before the first frame update
    void Start()
    {
        status = new Status();
        status.hp = 10;
        status.speed = 1;

        projectileShootCountAtOnce = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
