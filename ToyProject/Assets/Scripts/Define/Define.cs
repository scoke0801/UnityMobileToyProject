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
}