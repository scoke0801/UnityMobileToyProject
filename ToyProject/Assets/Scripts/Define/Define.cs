using UnityEditor;
using UnityEngine;

public class Define
{
    /// *-------------------------------------------------
    /// 
    /// -------------------------------------------------*
    public enum UIEvent
    {
        Click,
        Pressed,
        PointerDown,
        PointerUp,
    }

    public enum LayerType : int
    {
        Defualt = 0,
        TransparentFX,
        IgnoreRaycast,

        Water = 4,
        UI,

        Projectile = 7,
        Player,
    }

    /// *-------------------------------------------------
    /// 
    /// -------------------------------------------------*

    // 코드에서 사용할 목적으로 Scene이름과 동일하게 정의
    public enum Scene
    {
        None,
        TitleScene,
        SCENE_TYPE_LOADING,
        LobbyScene,
        GameScene,
        InfiniteGameScene,

        TestScene = 100,

        SCENE_INNER_TYPE_SHOP = 200,
        SCENE_INNER_TYPE_MANAGEMENT,
    }
    public enum ObjectType
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

    public enum ProjectileActType
    {
        PROJECTILE_ACT_TYPE_MIN = 0,
        PROJECTILE_ACT_TYPE_LINEAR = PROJECTILE_ACT_TYPE_MIN, // 선형
        PROJECTILE_ACT_TYPE_PARABOLA,                         // 포물선
        PROJECTILE_ACT_TYPE_VERTICAL_WAVE,                    // y축 파동
        PROJECTILE_ACT_TYPE_HORIZONTAL_WAVE,                  // x축 파동
        PROJECTILE_ACT_TYPE_TRACKING,                         // 추적
        OBJ_TYPE_MAX,
    };

    public enum PrefabTypeName
    {
        NONE = -1,
        PLAYER = 0,

        MONSTER_START = 1,
        MONSTER_GHOST_1 = MONSTER_START,
        MONSTER_GHOST_2,
        MONSTER_GOBLIN_MALE,
        MONSTER_GOBLIN_FEMALE,
        MONSTER_ROCK_GOLEM,
        MONSTER_SKELETON_KNIGHT,
        MONSTER_SKELETON_SLAVE,
        MONSTER_END = MONSTER_SKELETON_SLAVE,

        PROJECTILE,
        ATOM_BALL,
        INTECEPTOR,
        CHICKEN,
        CONDOR,

        BUDY,

        // For Test
        PARTICLE_START,
        PARTICLE_HIT_1 = PARTICLE_START,
        PARTICLE_HIT_2,
        PARTICLE_HIT_3,
        PARTICLE_HIT_4,
        PARTICLE_END = PARTICLE_HIT_4,

        // For Util
        SPAWNER,
        SCREEN_FADER,
    }

    public enum FadeType
    {
        FADE_TYPE_IN,
        FADE_TYPE_OUT,
    }


    /// *-------------------------------------------------
    /// const 
    /// -------------------------------------------------*
    public const int STAGE_WAVE_COUNT = 100;

	public const int HIT_PARTICLE_COUNT = 4;

	public const int HIT_PARTICLE_POOL_COUNT = 5;
	public const int PROJECTILE_POOL_COUNT = 30;

    public const float PLAYER_ATTACK_COOLTILE = 0.1f;

    public const float BUDY_BASE_ATTACK_COOLTILE = 0.2f;
    public const float BUDY_FORWARD_ATTACK_COOLTILE = 0.5f;
    public const float BUDY_ATTACK_HOLDINGTIME = 0.5f;

    public const int MAX_PROJECTILE_SHOOT_COUNT_AT_ONCE = 15;     // 한 번에 발사할 수 있는 총알의 개수. 

    public const float DASH_COOLTIME = 1.0f;
}