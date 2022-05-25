using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProjectileAct  
{
    public void DoMove(Projectile projectile);
}

public abstract class ProjectileActor : IProjectileAct
{
    protected GameObject shooter, target;
    protected Status status;
    protected Vector3 direction;
    public ProjectileActor(GameObject shooter, GameObject target, Vector3 shootPos)
    {
        this.shooter = shooter;
        this.target = target;
        CheckDirection(target, shootPos);
    }
    public virtual void DoMove(Projectile projectile)
    {
    }

    // 대상 객체로의 방향을 계산.
    protected void CheckDirection(GameObject target, Vector3 shootPos)
    { 
        Vector3 targetPosition = target.transform.position;

        direction = (targetPosition - shootPos).normalized;
    }
}
 
public class ProjectileLinearActor: ProjectileActor
{ 
    public ProjectileLinearActor(GameObject shooter, GameObject target, Vector3 shootPos) 
        : base(shooter, target, shootPos)
    {  
    }
    public override void DoMove(Projectile projectile)
    {
        Vector3 newPos = projectile.gameObject.transform.position + direction * 10.0f * Time.deltaTime;
        projectile.gameObject.transform.position = newPos;
    }
} 
public class ProjectileParabolaActor : ProjectileActor
{
    float power;
    float attenuation;
    public ProjectileParabolaActor(GameObject shooter, GameObject target, Vector3 shootPos)
          : base(shooter, target, shootPos)
    {
        attenuation = 15.0f;
        power = 10.0f;
        direction.y = 0.0f;
    }
    public override void DoMove(Projectile projectile)
    {
        Vector3 newPos = projectile.gameObject.transform.position + direction * 10.0f * Time.deltaTime;
        newPos.y = newPos.y + power * Time.deltaTime;
        power -= attenuation * Time.deltaTime;
        projectile.gameObject.transform.position = newPos;
    }
}
public class ProjectileVerticalWaveActor : ProjectileActor
{
    float angle = 0.0f;
    float curveSize = 3.0f;
    public ProjectileVerticalWaveActor(GameObject shooter, GameObject target, Vector3 shootPos)
             : base(shooter, target, shootPos)
    {
    }
    public override void DoMove(Projectile projectile)
    {
        Vector3 newPos = projectile.gameObject.transform.position + direction * 10.0f * Time.deltaTime;
         
        newPos.y = Mathf.Sin( angle * Mathf.Deg2Rad ) * curveSize;
        projectile.gameObject.transform.position = newPos;

        angle += 360 * Time.deltaTime;
        if (angle >= 360.0f)
        {
            angle = 0.0f;
        }
    }
}
public class ProjectileHorizontalWaveActor : ProjectileActor
{
    float angle = 0.0f;
    float curveSize = 3.0f;
    public ProjectileHorizontalWaveActor(GameObject shooter, GameObject target, Vector3 shootPos)
             : base(shooter, target, shootPos)
    {
    }
    public override void DoMove(Projectile projectile)
    { 
    }
}
public class ProjectileTrackingActor : ProjectileActor
{
    const float ORIGIN_TRACKING_TIME = 0.3f;
    float trackingTime;
    public ProjectileTrackingActor(GameObject shooter, GameObject target, Vector3 shootPos)
             : base(shooter, target, shootPos)
    {
        trackingTime = ORIGIN_TRACKING_TIME;
        CheckDirection(target, shootPos);
    }
    public override void DoMove(Projectile projectile)
    {
        if (!projectile.Target.activeSelf)
        {
            ObjectManager.instance.ReturnObject(OBJECT_TYPE.OBJ_PROJECTILE, projectile.gameObject);
            return;
        }
        trackingTime -= Time.deltaTime;
        if(trackingTime <= 0.0f)
        {
            trackingTime = ORIGIN_TRACKING_TIME;

            CheckDirection(target, projectile.gameObject.transform.position);
        } 

        Vector3 newPos = projectile.gameObject.transform.position + direction * 10.0f * Time.deltaTime;
        projectile.gameObject.transform.position = newPos;
    }
}