using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[AddComponentMenu("UI/Panel", 30)]
public class Panel : Selectable, IPointerClickHandler, IEventSystemHandler, ISubmitHandler
{
    protected Panel() { }

    public virtual void OnPointerClick(PointerEventData eventData) { }
    public virtual void OnSubmit(BaseEventData eventData) { }

} 