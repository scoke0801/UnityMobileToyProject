using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/ProjectileData", fileName = "Projectile Data")]
public class ProjectileData : ScriptableObject
{
    public float damage = 10;

    public int speed;
}
