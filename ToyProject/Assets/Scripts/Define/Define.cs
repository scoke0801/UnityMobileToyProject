using UnityEditor;
using UnityEngine;

public class Define
{
	public enum UIEvent
	{
		Click,
		Pressed,
		PointerDown,
		PointerUp,
	}

	public enum Scene
	{
		None,
		Title,
		Loading,
		Lobby,
		Game,
		Test,
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

    public enum PrefabTypeName
    {
        None = -1,
        Player = 0,

        MonsterStart = 1,
        MonsterGhost1 = MonsterStart,
        MonsterGhost2,
        MonsterGoblinMale,
        MonsterGoblinFemale,
        MonsterRockGolem,
        MonsterSkeletonKnight,
        MonsterSkeletonSlave,
        MonsterEnd = MonsterSkeletonSlave,

        Projectile,
        AtomBall,
        Inteceptor,
        Chicken,
        Condor,
        Spawner,

        Budy,

        // For Test
        ParticleStart,
        ParticleHit1 = ParticleStart,
        ParticleHit2,
        ParticleHit3,
        ParticleHit4,
        // ParticleEnd
    }
    public const int STAGE_WAVE_COUNT = 100;

	public const int HIT_PARTICLE_COUNT = 4;

	public const int HIT_PARTICLE_POOL_COUNT = 5;
	public const int PROJECTILE_POOL_COUNT = 30;
}