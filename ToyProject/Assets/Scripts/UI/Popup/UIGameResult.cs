using System.Collections;
using UnityEngine;

public class UIGameResult : UIPopup
{
	enum Panels
	{
		BasePanel,
		Panel1,
		Panel2,
		Panel3,
	}

	enum Texts
	{
		PlayerLevelText,
		TimeElapsedText,
		AcheivedEffectText,
		AcheivedEffectNameText,
		AcheivedEffectInfoText,
	}

	enum Buttons
	{
		ContinueButton,
		ExitButton, 
	}
	enum Images
	{
		AcheivedEffectIcon, 
	}

	public override bool Init()
	{
		if (base.Init() == false)
		{
			return false;
		}

		Debug.Log("UIGameResult::Init");

		BindPanel(typeof(Panels));
		BindText(typeof(Texts));
		BindButton(typeof(Buttons));
		BindImage(typeof(Images));

		GetButton((int)Buttons.ContinueButton).gameObject.BindEvent(OnClickContinueButton);
		GetButton((int)Buttons.ExitButton).gameObject.BindEvent(OnClickExitButton); 

		//GetText((int)Texts.StartButtonText).text = Managers.GetText(Define.StartButtonText);
		//GetText((int)Texts.ContinueButtonText).text = Managers.GetText(Define.ContinueButtonText);
		//GetText((int)Texts.CollectionButtonText).text = Managers.GetText(Define.CollectionButtonText);

		//Managers.Sound.Clear();
		//Managers.Sound.Play(Sound.Effect, "Sound_MainTitle");
		return true;
	}

	void OnClickContinueButton()
	{ 
		Debug.Log("OnClickContinueButton");
	}
	void OnClickExitButton()
	{ 
		Debug.Log("OnClickExitButton");
	} 
}