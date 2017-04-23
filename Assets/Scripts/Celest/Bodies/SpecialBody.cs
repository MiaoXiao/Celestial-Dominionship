using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBody : CelestialBody {

    //Information of the SpecialBody
    [SerializeField]
    private Special SpecialRef;


    protected override Celest GetCelest()
    {
        return SpecialRef;
    }

    private void Awake()
    {
        SpecialRef = Instantiate(SpecialRef);
    }

    public override void OnHit()
    {
        
    }

    //When the card is played
    public override void Play()
    {
        Activate.Instance.ActivateEffect(SpecialRef, GameManager.Instance.CurrentPlayer);
    }

}
