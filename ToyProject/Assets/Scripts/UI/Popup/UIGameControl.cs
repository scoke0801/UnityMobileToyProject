using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Define;

public class UIGameControl : UIPopup
{
	PlayerShooter _playerShooter;
	PlayerMovement _playerMovement;
	enum Texts
	{
		RemainTime,
		RemainMonsterWave,
		HeartText,
		AmmoText
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

		DebugWrapper.Log("UIGameControl::Init");
		 
		BindText(typeof(Texts));
		BindButton(typeof(Buttons)); 

		GetButton((int)Buttons.ControlMainButton).gameObject.BindEvent(OnClickContorlMainButton);
		GetButton((int)Buttons.ControlDashButton).gameObject.BindEvent(OnClickContorlDashButton);
		GetButton((int)Buttons.ControlReloadButton).gameObject.BindEvent(OnClickContorlReloadButton);
		GetButton((int)Buttons.ControlSubButton1).gameObject.BindEvent(OnClickContorlSub1Button);
		GetButton((int)Buttons.ControlSubButton2).gameObject.BindEvent(OnClickContorlSub2Button);
		GetButton((int)Buttons.ControlSubButton3).gameObject.BindEvent(OnClickContorlSub3Button);

		//Managers.Sound.Clear();
		//Managers.Sound.Play(Sound.Effect, "Sound_MainTitle");

		GameObject player = Managers.Game.Player;
		if (player)
		{
			_playerShooter = player.GetComponent<PlayerShooter>();
			_playerMovement = player.GetComponent<PlayerMovement>();

			UpdateAmmoText(_playerShooter.gun.curAmmo);
			UpdateWaveCount(0);
		}

		return true;
	}

	void OnClickContorlMainButton()
	{
		_playerShooter.Shoot();
		DebugWrapper.Log("OnClickContorlMainButton");
	}
	void OnClickContorlDashButton()
	{
		_playerMovement.Dash();
		DebugWrapper.Log("OnClickContorlDashButton");
	}
	void OnClickContorlReloadButton()
	{
		_playerShooter.ReloadGun();
		DebugWrapper.Log("OnClickContorlReloadButton");
	}
	void OnClickContorlSub1Button()
	{
		DebugWrapper.Log("OnClickContorlSub1Button");
	}
	void OnClickContorlSub2Button()
	{
		DebugWrapper.Log("OnClickContorlSub2Button");
	}
	void OnClickContorlSub3Button()
	{
		DebugWrapper.Log("OnClickContorlSub3Button");
	}

    public void UpdateGameTime(string text)
    {
		GetText((int)Texts.RemainTime).text = text;
	}

	public void UpdateWaveCount(int count)
	{
		GetText((int)Texts.RemainMonsterWave).text = $"Wave : {count}";
	}
	public void UpdateHeartText(int hp)
	{
		string text = $"x +{hp}";
		GetText((int)Texts.HeartText).text = text;
	}

    public void UpdateAmmoText(int ammo)
	{
		string text = $"x {ammo}";
		GetText((int)Texts.AmmoText).text = text; 
	} 
}
