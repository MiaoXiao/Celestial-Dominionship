using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Celest", menuName = "Celest/CreateDustObject", order = 3)]
public class Dust : Ranked {

    [SerializeField]
    protected int value;

    Dust(int _cost, object _model, int _tier, int _value)
    {
        cost = _cost;
        model = _model;
        tier = _tier;
        value = _value;
    }

    public override void Play()
    {
        // does stuff
    }
}
