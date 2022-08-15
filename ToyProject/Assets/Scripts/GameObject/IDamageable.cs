using UnityEditor;
using UnityEngine;
 
public interface IDamageable
{
    public void OnDamage(float damage, Vector3 hitPos, Vector3 hitNormal); 
} 