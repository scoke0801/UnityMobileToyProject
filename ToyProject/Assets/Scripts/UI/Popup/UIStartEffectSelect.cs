using System.Collections;
using UnityEngine;

public class UIStartEffectSelect : UIPopup
{
	enum Texts
	{
		TitleText,
		Text1,
		Text2,
		Text3,
	}

	enum Buttons
	{
		Button1,
		Button2,
		Button3,
	}
	enum Images
	{
		Image1,
		Image2,
		Image3,
	}

	public override bool Init()
	{
		if (base.Init() == false)
		{
			return false;
		}

		DebugWrapper.Log("UIEffectSelect::Init");

		BindText(typeof(Texts));
		BindButton(typeof(Buttons));
		BindImage(typeof(Images));

		GetButton((int)Buttons.Button1).gameObject.BindEvent(OnClickButton1);
		GetButton((int)Buttons.Button2).gameObject.BindEvent(OnClickButton2);
		GetButton((int)Buttons.Button3).gameObject.BindEvent(OnClickButton3);

		//GetText((int)Texts.StartButtonText).text = Managers.GetText(Define.StartButtonText);
		//GetText((int)Texts.ContinueButtonText).text = Managers.GetText(Define.ContinueButtonText);
		//GetText((int)Texts.CollectionButtonText).text = Managers.GetText(Define.CollectionButtonText);

		//Managers.Sound.Clear();
		//Managers.Sound.Play(Sound.Effect, "Sound_MainTitle");
		return true;
	}

	void OnClickButton1()
	{
		GameScene scene = (GameScene)Managers.Scene.CurrentScene;
		if (scene)
		{
			scene.ShowGameResult();
		}

		DebugWrapper.Log("OnClickButton1");
	}
	void OnClickButton2()
	{
		GameScene scene = (GameScene)Managers.Scene.CurrentScene;
		if (scene)
		{
			scene.ShowGameResult();
		}
		DebugWrapper.Log("OnClickButton2");
	}
	void OnClickButton3()
	{
		GameScene scene = (GameScene)Managers.Scene.CurrentScene;
		if (scene)
		{
			scene.ShowGameResult();
		}
		DebugWrapper.Log("OnClickButton3");
	}
}