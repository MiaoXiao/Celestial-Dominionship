using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Celest", menuName = "Celest/CreateAsteroidObject", order = 5)]
public class Asteroid : Meteor
{
    public override string GetDescription()
    {
        return "Inflict " + damage + " damage at target location.\n Impact Radius: " + radius;
    }
}
