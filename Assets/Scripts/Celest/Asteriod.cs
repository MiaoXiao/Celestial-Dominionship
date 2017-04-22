using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Celest", menuName = "Celest/CreateAsteriodObject", order = 5)]
public class Asteriod : Meteor
{

    Asteriod(int _cost, object _model, int _tier, int _damage, int _health, int _radius)
    {
        cost = _cost;
        model = _model;
        tier = _tier;
        damage = _damage;
        health = _health;
        radius = _radius;
    }

    public override void Play()
    {
        // does stuff
    }

}
