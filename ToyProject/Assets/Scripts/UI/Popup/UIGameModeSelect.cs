using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIGameModeSelect : UIPopup
{
	enum Texts
	{
		TitleText,
		ModeSelectOneText,
		ModeSelectTwoText,
		GameStartText,
	}

	enum Buttons
	{
		ModeOneSelectButton,
		ModeTwoSelectButton,
		GameStartButton,
		CloseButton,
	}
	//enum Images
	//{
	//	Image1,
	//	Image2,
	//	Image3,
	//}

	Define.Scene _sceneType;

	public override bool Init()
	{
		if (base.Init() == false)
		{
			return false;
		}

		DebugWrapper.Log("UIEffectSelect::Init");

		BindText(typeof(Texts));
		BindButton(typeof(Buttons));
		//BindImage(typeof(Images));

		GetButton((int)Buttons.ModeOneSelectButton).gameObject.BindEvent(OnClickModeOneSelectButton);
		GetButton((int)Buttons.ModeTwoSelectButton).gameObject.BindEvent(OnClickModeTwoSelectButton);
		GetButton((int)Buttons.GameStartButton).gameObject.BindEvent(OnClickGameStartButton);
		GetButton((int)Buttons.CloseButton).gameObject.BindEvent(OnClickCloseButton);

		_sceneType = Define.Scene.None;

		return true;
	}

	void OnClickModeOneSelectButton()
	{
		_sceneType = Define.Scene.GameScene;
	}
	void OnClickModeTwoSelectButton()
	{
		_sceneType = Define.Scene.InfiniteGameScene;
	}

	void OnClickGameStartButton()
	{
		Toy.ScreenFader screenFader = Toy.ScreenFaderEx.GetObject();
		screenFader.SetUp(Define.FadeType.FADE_TYPE_IN, 1.0f, 20.0f, null);

		// Managers.Scene.ChangeScene(_sceneType); 
	}
	void OnClickCloseButton()
	{
		Managers.UI.HidePopupUI<UIGameModeSelect>();
	}
}