using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Celest", menuName = "Celest/CreatePlanetObject", order = 1)]
public class Planet : Celest {

    [SerializeField]
    public List<Special> PassiveEffects; // LIST OF SPECIALS AKA EFFECTS
    [SerializeField]
    public int health; // HEALTH
    [SerializeField]
    public float distance; // DISTANCE FROM SUN

    public override string GetDescription()
    {
        return "Health " + health.ToString();
    }
}
