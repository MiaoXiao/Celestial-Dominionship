using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetBody : CelestialBody {

    Planet PlanetRef;
    List<Effect> OnDeath;
    List<Effect> OnPlay;
    List<Effect> OnStrike;
    List<Effect> OnTick;

    public override void Play()
    {
        foreach(Special x in PlanetRef.PassiveEffects)
        {
            switch (x.currentType)
            {
                case SType.OnDestroy:
                    OnDeath.Add(x.currentEffect);
                    break;
                case SType.OnPlay:
                    OnPlay.Add(x.currentEffect);
                    break;
                case SType.OnHit:
                    OnStrike.Add(x.currentEffect);
                    break;
                case SType.OnTick:
                    OnTick.Add(x.currentEffect);
                    break;
                default:
                    break;
            }

                
        }
    }

    public override void Display()
    {
        Instantiate<Mesh>(PlanetRef.model);
    }

    public override void OnHit()
    {
        throw new NotImplementedException();
    }
}
