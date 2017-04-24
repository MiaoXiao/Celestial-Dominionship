using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DustBody : CelestialBody
{
    [SerializeField]
    private Dust DustRef;

    private void OnEnable()
    {
        DustRef = Instantiate(DustRef);
        DustRef.name = DustRef.name.Replace("(Clone)", "").Trim();
    }

    public override Celest GetCelest()
    {
        return DustRef;
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        if (isLocked)
            return;

        //Debug.Log("Hit");
        if (owner == null)
        {
            Buy();
            return;
        }
        Play();
        owner.Discard.PopulateGrid(this);
        
    }

    public override void OnPointerUp(PointerEventData eventData)
    {

        return;

    }

    //When the object is hit on the grid
    public override void OnHit(Collider collision, MeteorBody meteor_body)
    {

    }

    public override void Play()
    {
        GameManager.Instance.CurrentPlayer.Dust += DustRef.value;
    }
}
