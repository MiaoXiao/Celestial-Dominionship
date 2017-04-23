using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "Celest", menuName = "Celest/CreateCelestObject", order = 1)]
public abstract class Celest : ScriptableObject{

    [SerializeField]
    public int playCost; // PRICE COST
    [SerializeField]
    public int purchaseCost;

    public abstract string GetDescription();
}
