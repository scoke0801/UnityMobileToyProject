using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
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
    PROJECTILE_ACT_TYPE_LINEAR = PROJECTILE_ACT_TYPE_MIN, // ����
    PROJECTILE_ACT_TYPE_PARABOLA,                         // ������
    PROJECTILE_ACT_TYPE_VERTICAL_WAVE,                    // y�� �ĵ�
    PROJECTILE_ACT_TYPE_HORIZONTAL_WAVE,                  // x�� �ĵ�
    PROJECTILE_ACT_TYPE_TRACKING,                         // ����
    OBJ_TYPE_MAX,
};
 
static class Constants
{
    public const float BUDY_ATTACK_COOLTILE = 0.2f; 
    public const float BUDY_ATTACK_HOLDINGTIME = 0.5f;
}