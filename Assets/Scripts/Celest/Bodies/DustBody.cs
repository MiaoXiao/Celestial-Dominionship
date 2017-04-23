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
    }

    protected override Celest GetCelest()
    {
        return DustRef;
    }

    public override void Play()
    {
        GameManager.Instance.CurrentPlayer.Dust += DustRef.value;
    }
}
