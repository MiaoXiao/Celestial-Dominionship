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
        eff = SpecialRef.currentEffect;
        switch (eff)
        {
            case Effect.Dust:
                break;
            case Effect.CardDraw:
                break;
            case Effect.Buys:
                break;
            case Effect.GenerateMeteor:
                break;
            case Effect.RotateGrid:
                break;
            case Effect.StarHealth:
                break;
            case Effect.Trash:
                break;
            default:
                break;
        }
    }


}
