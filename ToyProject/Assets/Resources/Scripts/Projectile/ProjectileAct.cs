using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProjectileAct  
{
    public void DoMove(GameObject gameObject);
}

public abstract class ProjectileActor : IProjectileAct
{ 
    public virtual void DoMove(GameObject gameObject)
    {
    }
}

// ���� ������ �ʿ��� ���� ??
public class ProjectileLinearActor: ProjectileActor
{
    public override void DoMove(GameObject gameObject) 
    { 
    }
} 
public class ProjectileParabolaActor : ProjectileActor
{
    public override void DoMove(GameObject gameObject)
    {
    }
}
public class ProjectileVerticalWaveActor : ProjectileActor
{
    public override void DoMove(GameObject gameObject)
    {
    }
}
public class ProjectileHorizontalWaveActor : ProjectileActor
{
    public override void DoMove(GameObject gameObject)
    {
    }
}
public class ProjectileTrackingActor : ProjectileActor
{
    public override void DoMove(GameObject gameObject)
    {
    }
}