using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Status status;
    // Start is called before the first frame update
    void Start()
    {
        status.hp = 10;
        status.speed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
