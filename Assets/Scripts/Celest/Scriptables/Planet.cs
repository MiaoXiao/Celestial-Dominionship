using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Celest", menuName = "Celest/CreatePlanetObject", order = 1)]
public class Planet : Celest
{
    public List<PlanetSpecial> PlanetEffects; // LIST OF SPECIALS AKA EFFECTS

    [SerializeField]
    public int health; // HEALTH
    [SerializeField]
    public float distance; // DISTANCE FROM SUN

    public override string GetDescription()
    {
        string desc = "";
        desc += "Health " + health.ToString();
        if (PlanetEffects.Count != 0)
        {
            desc += "\n Per Turn: ";
            foreach(PlanetSpecial special in PlanetEffects)
            {
                desc += "\n" + special.GetDescription();
            }
        }
        return desc;
    }
}
