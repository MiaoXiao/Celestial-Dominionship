using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBody : CelestialBody {

    Effect eff;
    [SerializeField]
    Special SpecialRef;

    private void Awake()
    {
        SpecialRef = Instantiate<Special>(SpecialRef);
    }

    public override void Display()
    {

    }

    public override void OnHit()
    {
        
    }

    public override void Play()
    {
        Activate.Instance.ActivateEffect(SpecialRef.currentEffect, SpecialRef.value);
    }


}
