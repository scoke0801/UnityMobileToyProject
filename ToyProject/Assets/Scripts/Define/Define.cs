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

	public const int STAGE_WAVE_COUNT = 30;
}