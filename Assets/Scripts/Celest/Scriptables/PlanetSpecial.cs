using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlanetEffect { Dust, CardDraw, GenerateMeteor, Buys }
public enum SType { OnTick, OnHit, OnDestroy, OnPlay, Passive }

[Serializable]
public class PlanetSpecial
{
    [SerializeField]
    public PlanetEffect currentEffect; // EFFECT, DUH
    public int value;
    public SType currentType;

    public bool affectsUser;

    public string GetDescription()
    {
        string desc = "";
        switch (currentEffect)
        {
            case PlanetEffect.Dust:
                desc += "Gain " + value + " Dust.";
                break;
            case PlanetEffect.Buys:
                desc += "Gain " + value + " extra Wormholes.";
                break;
            case PlanetEffect.CardDraw:
                desc += "Gain " + value + " extra Warps.";
                break;
            case PlanetEffect.GenerateMeteor:
                desc += "Generates " + value + " meteor(s)";
                break;
        }

        switch (currentType)
        {
            case SType.Passive:
                desc += " while this Planet is active.";
                break;
            case SType.OnDestroy:
                desc += " when this planet is destroyed.";
                break;
            case SType.OnHit:
                desc += " when this planet is hit.";
                break;
            case SType.OnPlay:
                desc += " for this turn only.";
                break;
            case SType.OnTick:
                desc += " per turn.";
                break;
        }


        return desc;
    }
}
