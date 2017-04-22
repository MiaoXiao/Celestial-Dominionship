using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetBody : CelestialBody {

    Player Owner;
    Planet PlanetRef;
    List<Special> Death;
    List<Special> Hit;
    List<Special> Tick;

    private void Awake()
    {
        PlanetRef = Instantiate<Planet>(PlanetRef);
    }

    public override void Play()
    {
        foreach(Special x in PlanetRef.PassiveEffects)
        {
            switch (x.currentType)
            {
                case SType.OnDestroy:
                    Death.Add(x);
                    break;
                case SType.OnPlay:
                    Activate.Instance.ActivateEffect(x.currentEffect, x.value, GameManager.Instance.CurrentPlayer);
                    break;
                case SType.OnHit:
                    Hit.Add(x);
                    break;
                case SType.OnTick:
                    GameManager.Instance.CurrentPlayer.passives += this.OnTick;
                    Tick.Add(x);
                    break;
                default:
                    break;
            }
        }
        Owner = GameManager.Instance.CurrentPlayer;
    }

    public override void Display()
    {
        Instantiate<Mesh>(PlanetRef.model);
    }

    public override void OnHit()
    {
        if (Hit.Count > 0)
        {
            foreach (Special x in Hit)
            {
                Activate.Instance.ActivateEffect(x.currentEffect, x.value, Owner);
            }
        }
        PlanetRef.health--;
        if(PlanetRef.health <= 0)
        {
            OnDeath();
        }

    }

    public void OnDeath()
    {
        if (Death.Count > 0)
        {
            foreach (Special x in Death)
            {
                Activate.Instance.ActivateEffect(x.currentEffect, x.value, Owner);
            }
        }
        Owner.passives -= this.OnTick;
    }

    public void OnTick()
    {
        foreach(Special x in Tick)
        {
            Activate.Instance.ActivateEffect(x.currentEffect, x.value, Owner);
        }
    }
}
