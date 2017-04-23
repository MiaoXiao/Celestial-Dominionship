using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetBody : CelestialBody
{
    [SerializeField]
    private Planet PlanetRef;

    private void Awake()
    {
        PlanetRef = Instantiate(PlanetRef);
        PlanetRef.name = PlanetRef.name.Replace("(Clone)", "").Trim();
    }

    protected override Celest GetCelest()
    {
        return PlanetRef;
    }

    public override void Play()
    {
        //Check when the effect will be used
        foreach(PlanetSpecial x in PlanetRef.PlanetEffects)
        {
            switch (x.currentType)
            {
                case SType.OnPlay:
                    Activate.Instance.ActivatePlanetEffect(x, GameManager.Instance.CurrentPlayer);
                    break;
                case SType.OnTick:
                    GameManager.Instance.CurrentPlayer.perTick += this.OnTick;
                    break;
                default:
                    break;
            }
        }
        
        owner = GameManager.Instance.CurrentPlayer;
    }

    //Will be called every time the planet is hit
    public override void OnHit()
    {
        foreach (PlanetSpecial x in PlanetRef.PlanetEffects)
        {
            if (x.currentType == SType.OnTick)
                Activate.Instance.ActivatePlanetEffect(x, owner);
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
        
        foreach (PlanetSpecial x in PlanetRef.PlanetEffects)
        {
            if (x.currentType == SType.OnDestroy)
                Activate.Instance.ActivatePlanetEffect(x, owner);
        }
        
        
        owner.perTick -= this.OnTick;
    }

    //Is called every turn
    public void OnTick()
    {
        foreach(PlanetSpecial x in PlanetRef.PlanetEffects)
        {
            if (x.currentType == SType.OnTick)
                Activate.Instance.ActivatePlanetEffect(x, owner);
        }
    }
}
