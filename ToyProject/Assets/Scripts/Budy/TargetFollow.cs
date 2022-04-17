using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollow : MonoBehaviour
{
    public GameObject player;

    private float radius;

    private float speed;
    private float angle;

    private void Awake()
    {
        speed = 3;
        angle = 0;
        radius = 3;
    }
    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        angle += Time.deltaTime * speed;

        Vector3 newPosition = player.transform.position; 

        newPosition.y = transform.position.y;

        newPosition.x += radius * Mathf.Cos(angle);
        newPosition.z += radius * Mathf.Sin(angle); 

        transform.position = newPosition; 
    }
     
}
