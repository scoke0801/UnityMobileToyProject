using System.Collections;
using UnityEngine;
 
public class UIPopup : UIBase
{
    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        Managers.UI.SetCanvas(gameObject, true);
        return true;
    }

    public virtual void ClosePopupUI()
    {
        Managers.UI.ClosePopupUI(this);
    }

    protected void ClosePopupUIWithDelay(float time)
    {
        StartCoroutine(ClosePopupUIWithDelay_Coroutine(time));
    }

    protected void HidePopupUIWithDelay(float time)
    {
        StartCoroutine(HidePopupUIWithDelay_Coroutine(time));
    }

    IEnumerator ClosePopupUIWithDelay_Coroutine(float time)
    {
        yield return new WaitForSeconds(time);

        Managers.UI.ClosePopupUI(this);
    }
    private IEnumerator HidePopupUIWithDelay_Coroutine(float time)
    {
        yield return new WaitForSeconds(time);

        Managers.UI.HidePopupUI(this);
    }
} 