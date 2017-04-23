using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Celest", menuName = "Celest/CreateDustObject", order = 3)]
public class Dust : Celest {

    [SerializeField]
    public int value;

    public override string GetDescription()
    {
        return "Gain " + value.ToString() + " Dust";
    }
}
