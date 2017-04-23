using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Meteor : Ranked
{
    [SerializeField]
    public int damage;
    [SerializeField]
    public int health;
    [SerializeField]
    public int radius;
    public float projectileSpeed = 30f;
}
