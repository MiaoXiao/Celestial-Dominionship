using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class CelestialBody : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler {

    protected Celest CelestRef;

    //When the card is played
    public virtual void Play()
    {

    }
    //When the object is hit on the grid
    public virtual void OnHit()
    {

    }
    //How to display the object
    public virtual void Display()
    {

    }
    public void Buy()
    {
        GameManager.Instance.CurrentPlayer.Dust -= CelestRef.purchaseCost;
        GameManager.Instance.CurrentPlayer.buysAvailible--;
        //GameManager.Instance.CurrentPlayer.AddDiscard
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        DragUtility.Instance.StartDrag(this.gameObject);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        DragUtility.Instance.EndDrag(this.gameObject);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }
}
