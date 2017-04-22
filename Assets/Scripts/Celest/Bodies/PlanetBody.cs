using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetBody : CelestialBody {
    [SerializeField]
    private Planet PlanetRef;

    Player Owner;


    List<Special> Death;
    List<Special> Hit;
    List<Special> Tick;

    private void Awake()
    {
        PlanetRef = Instantiate<Planet>(PlanetRef);
        CelestRef = PlanetRef;
    }

    public override void Play()
    {
        //Check when the effect will be used
        foreach(Special x in PlanetRef.PassiveEffects)
        {
            switch (x.currentType)
            {
                case SType.OnDestroy:
                    Death.Add(x);
                    break;
                case SType.OnPlay:
                    Activate.Instance.ActivateEffect(x, GameManager.Instance.CurrentPlayer);
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
    //Display the planet mesh
    public override void Display()
    {
        Instantiate<Mesh>(PlanetRef.model);
    }
    //Will be called every time the planet is hit
    public override void OnHit()
    {
        if (Hit.Count > 0)
        {
            foreach (Special x in Hit)
            {
                Activate.Instance.ActivateEffect(x, Owner);
            }
        }
        PlanetRef.health--;
        if(PlanetRef.health <= 0)
        {
            OnDeath();
        }

    }
    //When the planet dies
    public void OnDeath()
    {
        if (Death.Count > 0)
        {
            foreach (Special x in Death)
            {
                Activate.Instance.ActivateEffect(x, Owner);
            }
        }
        Owner.passives -= this.OnTick;
    }
    //Is called every turn
    public void OnTick()
    {
        foreach(Special x in Tick)
        {
            Activate.Instance.ActivateEffect(x, Owner);
        }
    }
}
