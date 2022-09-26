using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGetCard : UIPopup
{ 
	enum Images
	{
		CardImage,
	}

	UnityEngine.UI.Image _cardImage;
	Vector3 _cardPos;

	public override bool Init()
	{
		if (base.Init() == false)
		{
			return false;
		}

		DebugWrapper.Log("UIGetCard::Init");
		 
		BindImage(typeof(Images));
		_cardImage = GetImage((int)Images.CardImage);
		_cardPos = _cardImage.transform.position;
		 
		return true;
	} 

	public void RefreshUI()
    { 
		_cardPos.y += 100.0f;

		_cardImage.transform.position = _cardPos;

		HidePopupUIWithDelay(5.0f);
	} 
}
