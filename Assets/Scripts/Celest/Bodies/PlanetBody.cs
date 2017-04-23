using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetBody : CelestialBody
{
    [SerializeField]
    private Planet PlanetRef;

    private void OnEnable()
    {
        PlanetRef = Instantiate(PlanetRef);
        PlanetRef.name = PlanetRef.name.Replace("(Clone)", "").Trim();
    }

    public override Celest GetCelest()
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
                case PSType.Passive:
                    Activate.Instance.ActivatePlanetEffect(x, GameManager.Instance.CurrentPlayer);
                    break;
                case PSType.OnTick:
                    GameManager.Instance.CurrentPlayer.perTick += this.OnTick;
                    break;
                default:
                    break;
            }
        }
        
        owner = GameManager.Instance.CurrentPlayer;
    }

    //Will be called every time the planet is hit
    public override void OnHit(Collider collision, MeteorBody meteor_body)
    {
        print("PLANET HIT");

        foreach (PlanetSpecial x in PlanetRef.PlanetEffects)
        {
            if (x.currentType == PSType.OnTick)
                Activate.Instance.ActivatePlanetEffect(x, owner);
        }
        
        PlanetRef.population -= meteor_body.MeteorRef.damage;
        if(PlanetRef.population <= 0)
        {
            OnDeath();
        }

    }
    //When the planet dies
    public void OnDeath()
    {
        foreach (PlanetSpecial x in PlanetRef.PlanetEffects)
        {
            if (x.currentType == PSType.OnDestroy)
                Activate.Instance.ActivatePlanetEffect(x, owner);
        }
        
        if (owner != null)
            owner.perTick -= this.OnTick;

        gameObject.SetActive(false);
    }

    //Is called every turn
    public void OnTick()
    {
        foreach(PlanetSpecial x in PlanetRef.PlanetEffects)
        {
            if (x.currentType == PSType.OnTick)
                Activate.Instance.ActivatePlanetEffect(x, owner);
        }
    }
}
