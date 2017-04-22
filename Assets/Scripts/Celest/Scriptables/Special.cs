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
}
