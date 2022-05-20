using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProjectileAct  
{
    public void DoMove(GameObject gameObject);
}

public abstract class ProjectileActor : IProjectileAct
{
    protected GameObject shooter, target;
    protected Status status;
    public ProjectileActor(GameObject shooter, GameObject target )
    {
        this.shooter = shooter;
        this.target = target; 
    }
    public virtual void DoMove(GameObject gameObject)
    {
    }
}

// 개별 생성자 필요할 수도 ??
public class ProjectileLinearActor: ProjectileActor
{
    Vector3 direction;
    public ProjectileLinearActor(GameObject shooter, GameObject target, Vector3 shootPos) 
        : base(shooter, target)
    {
        Vector3 targetPosition = target.transform.position;

        direction = (targetPosition - shootPos).normalized;
    }
    public override void DoMove(GameObject gameObject)
    {
        Vector3 newPos = gameObject.transform.position + direction * 10.0f * Time.deltaTime;
        gameObject.transform.position = newPos;
    }
} 
public class ProjectileParabolaActor : ProjectileActor
{
    public ProjectileParabolaActor(GameObject shooter, GameObject target, Vector3 shootPos)
          : base(shooter, target)
    {
    }
    public override void DoMove(GameObject gameObject)
    {
    }
}
public class ProjectileVerticalWaveActor : ProjectileActor
{
    public ProjectileVerticalWaveActor(GameObject shooter, GameObject target, Vector3 shootPos)
             : base(shooter, target)
    {
    }
    public override void DoMove(GameObject gameObject)
    {
    }
}
public class ProjectileHorizontalWaveActor : ProjectileActor
{
    public ProjectileHorizontalWaveActor(GameObject shooter, GameObject target, Vector3 shootPos)
             : base(shooter, target)
    {
    }
    public override void DoMove(GameObject gameObject)
    {
    }
}
public class ProjectileTrackingActor : ProjectileActor
{
    public ProjectileTrackingActor(GameObject shooter, GameObject target, Vector3 shootPos)
             : base(shooter, target)
    {
    }
    public override void DoMove(GameObject gameObject)
    {
    }
}