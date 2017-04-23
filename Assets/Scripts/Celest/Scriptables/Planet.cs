using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Celest", menuName = "Celest/CreatePlanetObject", order = 1)]
public class Planet : Celest
{
    public List<PlanetSpecial> PlanetEffects; // LIST OF SPECIALS AKA EFFECTS

    [SerializeField]
    public int population; // HEALTH
    [SerializeField]
    public float distance; // DISTANCE FROM SUN

    public override string GetDescription()
    {
        bool hasPassive = false;
        bool hasTick = false;
        bool hasHit = false;
        bool hasDestroyed = false;
        foreach (PlanetSpecial special in PlanetEffects)
        {
            if (special.currentType == PSType.Passive)
                hasPassive = true;
            else if (special.currentType == PSType.OnTick)
                hasTick = true;
            else if (special.currentType == PSType.OnHit)
                hasHit = true;
            else if (special.currentType == PSType.OnDestroy)
                hasDestroyed = true;
        }

        string desc = "";
        desc += "Population: " + population.ToString() + " billion";

        if (hasPassive)
        {
            desc += "\n Passively: ";
            foreach (PlanetSpecial special in PlanetEffects)
            {
                if (special.currentType == PSType.Passive)
                    desc += "\n" + special.GetDescription();
            }
        }

        if (hasTick)
        {
            desc += "\n Per Turn: ";
            foreach (PlanetSpecial special in PlanetEffects)
            {
                if (special.currentType == PSType.OnTick)
                    desc += "\n" + special.GetDescription();
            }
        }

        if (hasHit)
        {
            desc += "\n When damaged: ";
            foreach (PlanetSpecial special in PlanetEffects)
            {
                if (special.currentType == PSType.OnHit)
                    desc += "\n" + special.GetDescription();
            }
        }

        if (hasDestroyed)
        {
            desc += "\n When destroyed: ";
            foreach (PlanetSpecial special in PlanetEffects)
            {
                if (special.currentType == PSType.OnDestroy)
                    desc += "\n" + special.GetDescription();
            }
        }
        return desc;
    }
}
