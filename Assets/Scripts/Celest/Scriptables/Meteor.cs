using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Meteor : Ranked
{
    [SerializeField]
    public int damage = 1;
    [SerializeField]
    public int radius = 0;
    public float projectileSpeed = 30f;
}
