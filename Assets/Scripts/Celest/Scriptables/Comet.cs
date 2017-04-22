using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Celest", menuName = "Celest/CreateCometObject", order = 4)]
public class Comet : Meteor {

    [SerializeField]
    public float distance;

    public override string GetDescription()
    {
        int pierce = health - 1;
        return "Launch a projectile " + distance + " tiles and inflict " + damage + " damage in radius " + radius + ". Pierces " + pierce + " objects.";
    }
}
