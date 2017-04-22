using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Celest", menuName = "Celest/CreateAsteriodObject", order = 5)]
public class Asteriod : Meteor
{
    public override string GetDescription()
    {
        int pierce = health - 1;
        return "Target a location of radius " + radius + " and inflict " + damage + " damage.";
    }
}
