using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class CelestialBody : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    public bool isLocked = false;
    public Player owner = null;

    public abstract Celest GetCelest();

    //When the card is played
    public abstract void Play();

    //When the object is hit on the grid
    public abstract void OnHit(Collider collision);

    private void OnTriggerEnter(Collider collision)
    {
        print("trigger enter with " + name);
        OnHit(collision);
    }

    /// <summary>
    /// This probably should not be here, buying an objject should not be handled by the object itself, but by some kind of store manager.
    /// </summary>
    public void Buy()
    {
        GameManager.Instance.CurrentPlayer.Dust -= GetCelest().purchaseCost;
        GameManager.Instance.CurrentPlayer.buysAvailible--;
        //GameManager.Instance.CurrentPlayer.AddDiscard
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("Hit");
        if(eventData.button == PointerEventData.InputButton.Left && !isLocked)
            DragUtility.Instance.StartDrag(this.gameObject);
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left && !isLocked)
            DragUtility.Instance.EndDrag(this.gameObject);
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        ToolTipUtility.Instance.ShowToolTip(this);
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        ToolTipUtility.Instance.HideToolTip("Celest");
    }
}
