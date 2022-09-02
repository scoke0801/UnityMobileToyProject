using System.Collections;
using UnityEngine;

public class UIGameResult : UIPopup
{ 
	enum Texts
	{
		PlayerLevelValueText,
		TimeElapsedValueText,
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

		DebugWrapper.Log("UIGameResult::Init");
		 
		BindText(typeof(Texts));
		BindButton(typeof(Buttons));
		BindImage(typeof(Images));

		GetButton((int)Buttons.ContinueButton).gameObject.BindEvent(OnClickContinueButton);
		GetButton((int)Buttons.ExitButton).gameObject.BindEvent(OnClickExitButton);

		//GetText((int)Texts.StartButtonText).text = Managers.GetText(Define.StartButtonText);
		//GetText((int)Texts.ContinueButtonText).text = Managers.GetText(Define.ContinueButtonText);
		//GetText((int)Texts.CollectionButtonText).text = Managers.GetText(Define.CollectionButtonText);

		GameScene scene = (GameScene)(Managers.Scene.CurrentScene);
		if (scene)
		{
			UpdateElapseGameTimeText(scene.ElapsedTime);
			UpdatePlayerLevelText(1, 3);
		}
		//Managers.Sound.Clear();
		//Managers.Sound.Play(Sound.Effect, "Sound_MainTitle");
		return true;
	}

	void OnClickContinueButton()
	{
		DebugWrapper.Log("OnClickContinueButton");
	}
	void OnClickExitButton()
	{
		DebugWrapper.Log("OnClickExitButton");
	}

	public void UpdateElapseGameTimeText(float elapsedTime)
	{
		int min = (int)(elapsedTime / 60.0f);
		int sec = (int)(elapsedTime - min * 60.0f);
		GetText((int)Texts.TimeElapsedValueText).text = $"{min}분   {sec}초";
	}

	public void UpdatePlayerLevelText(int nPrevLevel, int nCurrentLevel)
	{
		GetText((int)Texts.PlayerLevelValueText).text = $"{nPrevLevel}		->		{nCurrentLevel}";
	}
}