using UnityEditor;
using UnityEngine;
  
public class Atomball : Projectile
{
    new void Start()
    {
        base.Start(); 
    }
     
    
    new public void Update()
    {
        if (status.attackCoolTime >= 0.0f)
        {
            status.UpdateAttackCoolTime();
            if (status.attackCoolTime <= 0.0f)
            { 
                this.gameObject.SetActive(true);
            } 
        }
    }
    new void OnCollisionEnter(Collision collision)
    { 
        if (collision.gameObject == GameManager.instance.GetPlayerObject())
        {
            return;
        }
        if (collision.gameObject.tag == "Projectile")
        {
            return;
        }

        Debug.Log("Atom!!!");
        this.gameObject.SetActive(false); 
        status.attackCoolTime += 5.0f;
        // ObjectManager.instance.ReturnObject(OBJECT_TYPE.OBJ_PROJECTILE, this.gameObject);
    }
} 