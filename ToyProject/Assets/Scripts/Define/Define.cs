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
	public const int STAGE_WAVE_COUNT = 30;

	public const int HIT_PARTICLE_COUNT = 4;

	public const int HIT_PARTICLE_POOL_COUNT = 5;
	public const int PROJECTILE_POOL_COUNT = 30;
}