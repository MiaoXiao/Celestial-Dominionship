using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Celest", menuName = "Celest/CreatePlanetObject", order = 1)]
public class Planet : Celest {

    [SerializeField]
    protected List<Special> PassiveEffects; // LIST OF SPECIALS AKA EFFECTS
    [SerializeField]
    protected int health; // HEALTH
    [SerializeField]
    protected float distance; // DISTANCE FROM SUN
}
