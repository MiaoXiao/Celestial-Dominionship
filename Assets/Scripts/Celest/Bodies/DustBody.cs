using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DustBody : RankedBody
{
    [SerializeField]
    private Dust DustRef;

    private void Awake()
    {
        DustRef = Instantiate(DustRef);
        DustRef.name = DustRef.name.Replace("(Clone)", "").Trim();
    }

    protected override Celest GetCelest()
    {
        return DustRef;
    }


    //When the object is hit on the grid
    public override void OnHit()
    {

    }

    public override void Play()
    {
        GameManager.Instance.CurrentPlayer.Dust += DustRef.value;
    }
}
