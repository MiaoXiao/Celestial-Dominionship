using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CelestialBody : MonoBehaviour {

    public abstract void Play();

    public abstract void OnHit();

    public abstract void Display();
}
