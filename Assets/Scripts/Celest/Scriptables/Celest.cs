using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "Celest", menuName = "Celest/CreateCelestObject", order = 1)]
public abstract class Celest : ScriptableObject{

    [SerializeField]
    protected int cost; // PRICE COST
    [SerializeField]
    protected object model; // MODEL LOCATION, CURRENTLY OBJECT UNTIL REPLACED WITH CURRENT SHIT
    
}
