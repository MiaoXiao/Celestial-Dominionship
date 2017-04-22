using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Effect { Dust, StarHealth, CardDraw, RotateGrid, GenerateMeteor, Buys, Trash }
enum SType { OnTick, OnHit, OnDestroy, OnPlay }

[CreateAssetMenu(fileName = "Celest", menuName = "Celest/CreateSpecialObject", order = 2)]
public class Special : Celest {
    
    [SerializeField]
    Effect currentEffect; // EFFECT, DUH
    [SerializeField]
    SType currentType; // WHAT TRIGGERS THE EFFECT

    Special(Effect _effect, SType _type)
    {
        currentEffect = _effect;
        currentType = _type;
    }

    Special(int _cost, object _model, Effect _effect, SType _type)
    {
        cost = _cost;
        model = _model;
        currentEffect = _effect;
        currentType = _type;
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
