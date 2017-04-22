using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CelestialBody : MonoBehaviour {

	protected Celest CelestRef;

    public abstract void Play();

    public abstract void OnHit();

    public abstract void Display();
}
