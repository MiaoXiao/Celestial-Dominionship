using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlanetEffect { Dust, CardDraw, GenerateMeteor, Buys }
public enum PSType { OnTick, OnHit, OnDestroy, Passive }

[Serializable]
public class PlanetSpecial
{
    [SerializeField]
    public PlanetEffect currentEffect; // EFFECT, DUH
    public int value;
    public PSType currentType;

    public bool affectsUser;

    public string GetDescription()
    {
        string desc = "";
        switch (currentEffect)
        {
            case PlanetEffect.Dust:
                desc += "+" + value + " Dust.";
                break;
            case PlanetEffect.Buys:
                desc += "+" + value + " Wormholes.";
                break;
            case PlanetEffect.CardDraw:
                desc += "+" + value + " Warps.";
                break;
            case PlanetEffect.GenerateMeteor:
                desc += "Generate " + value + " meteor(s).";
                break;
        }

        return desc;
    }
}
