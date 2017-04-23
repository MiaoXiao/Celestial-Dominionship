using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class CelestialBody : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    public bool isLocked = false;
    public bool inShop = true;
    public Player owner = null;

    protected abstract Celest GetCelest();

    //When the card is played
    public abstract void Play();

    //When the object is hit on the grid
    public abstract void OnHit();

    public void Buy()
    {
        GameManager.Instance.CurrentPlayer.Dust -= GetCelest().purchaseCost;
        GameManager.Instance.CurrentPlayer.buysAvailible--;
        inShop = false;
        //GameManager.Instance.CurrentPlayer.AddDiscard
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        DragUtility.Instance.StartDrag(this.gameObject);
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        DragUtility.Instance.EndDrag(this.gameObject);
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        ToolTipUtility.Instance.ShowToolTip(GetCelest());
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        ToolTipUtility.Instance.HideToolTip("Celest");
    }
}
