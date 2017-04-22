using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBody : CelestialBody {

    Effect eff;

    private void Awake()
    {
        CelestRef = Instantiate<Special>(CelestRef);
    }

    public override void Display()
    {

    }

    public override void OnHit()
    {
        
    }

    public override void Play()
    {
        eff = CelestRef.GetComponent<Special>().currentEffect;
        switch (eff)
        {
            case eff == "-Dust":
                break;
        }
    }


}
