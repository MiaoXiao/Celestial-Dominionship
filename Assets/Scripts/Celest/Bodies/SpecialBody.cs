using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBody : CelestialBody
{

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
        SpecialRef.name = SpecialRef.name.Replace("(Clone)", "").Trim();
    }

    public override void OnHit()
    {
        return;
    }

    //When the card is played
    public override void Play()
    {
        Activate.Instance.ActivateSpecialEffect(SpecialRef, GameManager.Instance.CurrentPlayer);
    }

}
