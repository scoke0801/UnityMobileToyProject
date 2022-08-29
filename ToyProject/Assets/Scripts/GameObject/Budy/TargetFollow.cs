using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollow : MonoBehaviour
{
    public GameObject target = null;

    private float radius;

    private float speed;
    private float angle;

    private void Awake()
    {
        speed = 1;
        angle = 0;
        radius = 3;
    }
    public void SetTarget(GameObject target, float radius, float speed, float angle)
    {
        this.target = target;
        this.radius = radius;
        this.speed = speed;
        this.angle = angle;
    }
      
    public void Update()
    {
        Vector3 dir = target.transform.forward * 10000;
        dir.y = transform.position.y;
        transform.LookAt(dir, Vector3.up);

        angle += Time.deltaTime * speed;

        Vector3 newPosition = target.transform.position; 

        newPosition.y = transform.position.y;

        newPosition.x += radius * Mathf.Cos(angle);
        newPosition.z += radius * Mathf.Sin(angle); 

        transform.position = newPosition; 
    }
     
}
