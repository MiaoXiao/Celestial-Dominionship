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

    void Start()
    {
        CalculateDistance();
    }

    Planet(int _cost, object _model, List<Special>_PassiveEffects, int _health)
    {
        cost = _cost;
        model = _model;
        PassiveEffects = _PassiveEffects;
        health = _health;
    }

    private void CalculateDistance()
    {
        distance = 0;
    }
	
	public override void Play()
    {
        // does stuff
    }

    public void OnDestroy()
    {
        // does stuff
    }

    public void OnTick()
    {
        // does stuff
    }
}
