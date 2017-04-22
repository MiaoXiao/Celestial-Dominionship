using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Celest", menuName = "Celest/CreateCometObject", order = 4)]
public class Comet : Meteor {

    [SerializeField]
    protected float distance;

    void Start()
    {
        CalculateDistance();
    }

    Comet(int _cost, object _model, int _tier, int _damage, int _health, int _radius)
    {
        cost = _cost;
        model = _model;
        tier = _tier;
        damage = _damage;
        health = _health;
        radius = _radius;
    }

    private void CalculateDistance()
    {
        distance = 0;
    }

    public override void Play()
    {
        // does stuff
    }

}
