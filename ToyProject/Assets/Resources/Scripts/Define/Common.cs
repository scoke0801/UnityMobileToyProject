using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common 
{

}

public enum OBJECT_TYPE
{
    OBJ_TYPE_MIN = 0,
    OBJ_MONSTER_CONDER = OBJ_TYPE_MIN,
    OBJ_MONSTER_DRAGON,
    OBJ_Projectile,
    OBJ_TYPE_MAX,
};

public class Status
{
    public float speed;
    public float hp;
    public float attackCoolTime;
    public float damage;
  
}
