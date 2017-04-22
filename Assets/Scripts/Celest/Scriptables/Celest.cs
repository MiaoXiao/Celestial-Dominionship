﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "Celest", menuName = "Celest/CreateCelestObject", order = 1)]
public abstract class Celest : ScriptableObject{

    [SerializeField]
    public int playCost; // PRICE COST
    [SerializeField]
    public int purchaseCost;
    [SerializeField]
    public Mesh model; // MODEL LOCATION, CURRENTLY OBJECT UNTIL REPLACED WITH CURRENT SHIT


    public abstract string GetDescription();
}
