using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CelestialBody : MonoBehaviour {
    //When the card is played
    public abstract void Play();
    //When the object is hit on the grid
    public abstract void OnHit();
    //How to display the object
    public abstract void Display();
}
