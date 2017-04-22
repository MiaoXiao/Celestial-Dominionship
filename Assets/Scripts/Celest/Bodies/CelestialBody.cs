using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CelestialBody : MonoBehaviour {

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

}
