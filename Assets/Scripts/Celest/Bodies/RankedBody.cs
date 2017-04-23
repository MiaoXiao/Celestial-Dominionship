using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RankedBody : CelestialBody
{
    public override void OnHit()
    {
        throw new NotImplementedException();
    }

    public override void Play()
    {
        throw new NotImplementedException();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
