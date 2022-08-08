using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public string moveAixName = "Vertical";
    public string rotateAxisName = "Horizontal";
    
    public float move { get; private set; }
    public float rotate { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis(moveAixName);

        rotate = Input.GetAxis(rotateAxisName);
    }
}
