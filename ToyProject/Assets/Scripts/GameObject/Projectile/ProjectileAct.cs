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

    public ProjectileActor() { }
    public ProjectileActor(GameObject shooter, Vector3 direction, Vector3 shootPos)
    {
        this.shooter = shooter;
        this.direction = direction; 
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
    static public ProjectileActor GetProjectileActor(PROJECTILE_ACT_TYPE actType, GameObject shooter, GameObject target, Vector3 shootPos)
    { 
        switch (actType)
        { 
            case PROJECTILE_ACT_TYPE.PROJECTILE_ACT_TYPE_TRACKING:
                {
                    return new ProjectileTrackingActor(shooter, target, shootPos);
                } 
            default:
                {
                    // to do 
                    // error
                    Debug.LogError("GetProjectileActor TypeError");
                }
                break;
        }
        return null;
    }

    static public ProjectileActor GetProjectileActor(PROJECTILE_ACT_TYPE actType, GameObject shooter, Vector3 direction, Vector3 shootPos)
    {
        switch (actType)
        {
            case PROJECTILE_ACT_TYPE.PROJECTILE_ACT_TYPE_LINEAR:
                {
                    return new ProjectileLinearActor(shooter, direction, shootPos);
                }
            case PROJECTILE_ACT_TYPE.PROJECTILE_ACT_TYPE_PARABOLA:
                {
                    return new ProjectileParabolaActor(shooter, direction, shootPos);
                }
            case PROJECTILE_ACT_TYPE.PROJECTILE_ACT_TYPE_VERTICAL_WAVE:
                {
                    return new ProjectileVerticalWaveActor(shooter, direction, shootPos);
                } 
            default:
                {
                    // to do 
                    // error
                    Debug.LogError("GetProjectileActor TypeError");
                }
                break;
        }
        return null;
    }
}
 
public class ProjectileLinearActor: ProjectileActor
{  
    public ProjectileLinearActor(GameObject shooter, Vector3 direction, Vector3 shootPos)
        : base(shooter, direction, shootPos)
    {
    }
    public override void DoMove(Projectile projectile)
    {
        Vector3 newPos = projectile.gameObject.transform.position + direction * 30.0f * Time.deltaTime;
        projectile.gameObject.transform.position = newPos;
    }
} 
public class ProjectileParabolaActor : ProjectileActor
{
    float power;
    float attenuation;
    public ProjectileParabolaActor(GameObject shooter, Vector3 direction, Vector3 shootPos)
          : base(shooter, direction, shootPos)
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
    public ProjectileVerticalWaveActor(GameObject shooter, Vector3 direction, Vector3 shootPos)
             : base(shooter, direction, shootPos)
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
    public ProjectileHorizontalWaveActor(GameObject shooter, Vector3 direction, Vector3 shootPos)
             : base(shooter, direction, shootPos)
    {
    }
    public override void DoMove(Projectile projectile)
    { 
    }
}
public class ProjectileTrackingActor : ProjectileActor
{
    const float ORIGIN_TRACKING_TIME = 0.15f;
    float trackingTime;
    public ProjectileTrackingActor(GameObject shooter, GameObject target, Vector3 shootPos) : base()
    {
        this.target = target;
        trackingTime = ORIGIN_TRACKING_TIME;
        CheckDirection(target, shootPos);
    } 
    public override void DoMove(Projectile projectile)
    {
        if (!target.activeSelf)
        {
            Managers.Pool.Push(projectile.gameObject);
            // ObjectManager.instance.ReturnObject(OBJECT_TYPE.OBJ_PROJECTILE, projectile.gameObject);
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