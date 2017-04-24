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
    public abstract void OnHit(Collider collision, MeteorBody mmeteor_body);

    private void OnTriggerEnter(Collider collision)
    {
        CelestialBody celestial_body = collision.gameObject.GetComponent<CelestialBody>();
        if (celestial_body == null)
            return;

        print(name + " has trigger event with " + collision.name);

        if (celestial_body is MeteorBody)
            OnHit(collision, (MeteorBody)celestial_body);
        else
            OnHit(collision, null);
    }

    /// <summary>
    /// Show or hide mesh for this celest body
    /// </summary>
    public bool IsVisible
    {
        get
        {
            return GetComponent<MeshRenderer>().enabled;
        }
        set
        {
            GetComponent<MeshRenderer>().enabled = value;
        }
    }

    /// <summary>
    ///Check if current player has enough dust to purchase and enough buys
    ///If so, set this owner to current player, and move this celest body to thaat player's discard
    /// </summary>
    public void Buy()
    {
        print("attempting to buy " + GetCelest().name);

        Player curr_player = GameManager.Instance.CurrentPlayer;
        if (curr_player == null)
            throw new Exception("Current player is null.");

        if (curr_player.Dust < GetCelest().purchaseCost ||
            curr_player.Buys <= 0)
        {
            Debug.Log("Insufficient Funds");
            return;
        }

        curr_player.Dust -= GetCelest().purchaseCost;
        curr_player.Buys--;
        curr_player.DiscardDeck.Add(this);
        //curr_player.

        //Add Discard animation
        //Move to object pooler

        owner = curr_player;
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
            //Debug.Log("Hit");
            if (owner == null)
            {
                Buy();
            }
        else if (eventData.button == PointerEventData.InputButton.Left && !isLocked)
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
