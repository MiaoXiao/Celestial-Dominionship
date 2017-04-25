﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlanetBody : DestroyableBody
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
        print("play planet");
        GameManager.Instance.CurrentPlayer.Dust -= PlanetRef.playCost;
        //Check when the effect will be used
        foreach (PlanetSpecial x in PlanetRef.PlanetEffects)
        {
            switch (x.currentType)
            {
                case PSType.Passive:
                    Activate.Instance.ActivatePlanetEffect(x, GameManager.Instance.CurrentPlayer);
                    break;
                case PSType.OnTick:
                    GameManager.Instance.CurrentPlayer.perTick += this.OnTick;
                    break;
                case PSType.OnHit:
                    //Do nothing
                    break;
                case PSType.OnDestroy:
                    //Do nothing
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
        print("PLANET HIT by " + collision.name);

        foreach (PlanetSpecial x in PlanetRef.PlanetEffects)
        {
            if (x.currentType == PSType.OnHit)
                Activate.Instance.ActivatePlanetEffect(x, owner);
        }

        if (meteor_body == null)
            return;

        PlanetRef.population -= meteor_body.GetMeteor().damage;
        if(PlanetRef.population <= 0)
        {
            OnDeath();
        }

    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        if (isLocked)
            return;

        //Debug.Log("Hit");
        if (owner == null)
        {
            Buy();
            return;
        }

        if (GameManager.Instance.CurrentPlayer.Dust < PlanetRef.playCost && gameObject.tag != "Sun")
        {
            return;
        }

        if (eventData.button == PointerEventData.InputButton.Left && !isLocked)
        {
            gameObject.GetComponent<Collider>().enabled = false;
            DragUtility.Instance.StartDrag(this.gameObject);
        }

    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        if (GameManager.Instance.CurrentPlayer.Dust < PlanetRef.playCost && gameObject.tag != "Sun")
        {
            return;
        }

        if (eventData.button == PointerEventData.InputButton.Left && !isLocked)
        {
            gameObject.GetComponent<Collider>().enabled = true;
            if (DragUtility.Instance.EndDrag(this.gameObject) && isLocked)
            {
                Play();
            }
               
        }

    }

    //When the planet dies
    public void OnDeath()
    {
        print("Planet died");
        foreach (PlanetSpecial x in PlanetRef.PlanetEffects)
        {
            if (x.currentType == PSType.OnDestroy)
                Activate.Instance.ActivatePlanetEffect(x, owner);
        }
        
        if (owner != null)
            owner.perTick -= this.OnTick;

        ToolTipUtility.Instance.HideToolTip("Celest");

        //TODO: need to disable this planet's passives here

        if (gameObject.tag == "Sun")
        {
            owner.sunsLeft--;
        }
            

        owner = null;

        Destroy(gameObject);
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
