using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public enum OBJECT_TYPE
{
    OBJ_TYPE_MIN = 0,
    OBJ_MONSTER_GHOST_MALE = OBJ_TYPE_MIN,
    OBJ_MONSTER_GHOST_FEMALE,
    OBJ_MONSTER_ROCK_GOLEM,
    OBJ_MONSTER_SKELETON_KNIGHT,
    OBJ_MONSTER_SKELETON_SLAVE,
    OBJ_MONSTER_GOBLIN_MALE,
    OBJ_MONSTER_GOBLIN_FEMALE,
    OBJ_PROJECTILE,
    OBJ_METAL_PROJECTILE,
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
 
static class Constants
{ 
    public const float PLAYER_ATTACK_COOLTILE = 0.1f;

    public const float BUDY_BASE_ATTACK_COOLTILE = 0.2f;
    public const float BUDY_FORWARD_ATTACK_COOLTILE = 0.5f;
    public const float BUDY_ATTACK_HOLDINGTIME = 0.5f;

    public const int MAX_PROJECTILE_SHOOT_COUNT_AT_ONCE = 15;     // 한 번에 발사할 수 있는 총알의 개수.
}
