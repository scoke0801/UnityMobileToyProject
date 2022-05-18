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
    OBJ_MONSTER_CHICKEN,
    OBJ_PROJECTILE,
    OBJ_TYPE_MAX,
};

public enum PROJECTILE_ACT_TYPE
{
    PROJECTILE_ACT_TYPE_MIN = 0,
    PROJECTILE_ACT_TYPE_LINEAR = PROJECTILE_ACT_TYPE_MIN, // 선형
    PROJECTILE_ACT_TYPE_PARABOLA,                         // 포물선
    PROJECTILE_ACT_TYPE_VERTICAL_WAVE,                    // y축 파동
    PROJECTILE_ACT_TYPE_HORIZONTAL_WAVE,                  // x축 파동
    PROJECTILE_ACT_TYPE_TRACKING,                         // 추적
    OBJ_TYPE_MAX,
};

public class Status
{
    public float speed;
    public float hp;
    public float attackCoolTime;
    public float damage;
  
}
