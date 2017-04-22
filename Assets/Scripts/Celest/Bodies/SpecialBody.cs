﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBody : CelestialBody {

    //Information of the SpecialBody
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
    //When the card is played
    public override void Play()
    {
        Activate.Instance.ActivateEffect(SpecialRef, GameManager.Instance.CurrentPlayer);
    }


}
