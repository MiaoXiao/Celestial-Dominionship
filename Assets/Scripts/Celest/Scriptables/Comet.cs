using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Celest", menuName = "Celest/CreateCometObject", order = 4)]
public class Comet : Meteor
{
    public override string GetDescription()
    {
        return "Launches a projecile that inflicts " + damage + " damage.\n Impact Radius: " + radius + " tile(s).\n Pierces " + piercing + " objects.";
    }
}
