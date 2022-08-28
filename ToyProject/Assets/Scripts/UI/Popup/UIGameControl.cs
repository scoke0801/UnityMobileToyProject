using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Define;

public class UIGameControl : UIPopup
{ 
	enum Texts
	{
		RemainTime,
		RemainMonsterWave, 
	}

	enum Buttons
	{
		ControlMainButton,
		ControlDashButton,
		ControlReloadButton,
		ControlSubButton1,
		ControlSubButton2,
		ControlSubButton3
	}
 
	public override bool Init()
	{
		if (base.Init() == false)
		{
			return false;
		}

		Debug.Log("UIGameControl::Init");
		 
		BindText(typeof(Texts));
		BindButton(typeof(Buttons)); 

		GetButton((int)Buttons.ControlMainButton).gameObject.BindEvent(OnClickContorlMainButton);
		GetButton((int)Buttons.ControlDashButton).gameObject.BindEvent(OnClickContorlDashButton);
		GetButton((int)Buttons.ControlReloadButton).gameObject.BindEvent(OnClickContorlReloadButton);
		GetButton((int)Buttons.ControlSubButton1).gameObject.BindEvent(OnClickContorlSub1Button);
		GetButton((int)Buttons.ControlSubButton2).gameObject.BindEvent(OnClickContorlSub2Button);
		GetButton((int)Buttons.ControlSubButton3).gameObject.BindEvent(OnClickContorlSub3Button);

		//GetText((int)Texts.StartButtonText).text = Managers.GetText(Define.StartButtonText);
		//GetText((int)Texts.ContinueButtonText).text = Managers.GetText(Define.ContinueButtonText);
		//GetText((int)Texts.CollectionButtonText).text = Managers.GetText(Define.CollectionButtonText);
		
		//Managers.Sound.Clear();
		//Managers.Sound.Play(Sound.Effect, "Sound_MainTitle");
		return true;
	}

	void OnClickContorlMainButton()
	{
		Debug.Log("OnClickContorlMainButton");
	}
	void OnClickContorlDashButton()
	{
		Debug.Log("OnClickContorlDashButton");
	}
	void OnClickContorlReloadButton()
	{
		Debug.Log("OnClickContorlReloadButton");
	}
	void OnClickContorlSub1Button()
	{
		Debug.Log("OnClickContorlSub1Button");
	}
	void OnClickContorlSub2Button()
	{
		Debug.Log("OnClickContorlSub2Button");
	}
	void OnClickContorlSub3Button()
	{
		Debug.Log("OnClickContorlSub3Button");
	}

    public void UpdateGameTime(string text)
    {
		GetText((int)Texts.RemainTime).text = text;
	}

	public void UpdateWaveCount(string text)
	{
		GetText((int)Texts.RemainMonsterWave).text = text;
	}
}
