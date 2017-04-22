using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Effect { Dust, StarHealth, CardDraw, RotateGrid, GenerateMeteor, Buys, Trash }
public enum SType { OnTick, OnHit, OnDestroy, OnPlay }

[CreateAssetMenu(fileName = "Celest", menuName = "Celest/CreateSpecialObject", order = 2)]
public class Special : Celest {
    
    [SerializeField]
    public Effect currentEffect; // EFFECT, DUH
    [SerializeField]
    public SType currentType; // WHAT TRIGGERS THE EFFECT
}
