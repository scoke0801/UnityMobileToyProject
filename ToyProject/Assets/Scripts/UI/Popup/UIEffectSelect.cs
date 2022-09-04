using System.Collections;
using UnityEngine;

public class UIEffectSelect : UIPopup
{ 
	enum Texts
	{
		TitleText,
		Text1,
		Text2,
		Text3,
		ChangeText,
	}

	enum Buttons
	{
		Button1,
		Button2,
		Button3,
		ChangeButton,
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
		GetButton((int)Buttons.ChangeButton).gameObject.BindEvent(OnClickChangeButton);
		  
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

	void OnClickChangeButton()
	{ 
	}
}