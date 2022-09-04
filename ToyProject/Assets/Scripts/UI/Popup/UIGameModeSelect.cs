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

	SceneType _sceneType;

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

		_sceneType = SceneType.NONE;

		return true;
	}

	void OnClickModeOneSelectButton()
	{
		_sceneType = SceneType.GAME;
	}
	void OnClickModeTwoSelectButton()
	{
		_sceneType = SceneType.GAME_INFINITE;
	}

	void OnClickGameStartButton()
	{
        switch (_sceneType)
        {
			case SceneType.GAME:
				{
					SceneManager.LoadScene("GameScene");
				}
				break;
			case SceneType.GAME_INFINITE:
				{
					SceneManager.LoadScene("InfiniteGameScene");
				}
				break;
		} 
	}
	void OnClickCloseButton()
	{
		Managers.UI.HidePopupUI<UIGameModeSelect>();
	}
}