using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometBody : MeteorBody
{
    [SerializeField]
    private Comet CometRef;

    protected override Celest GetCelest()
    {
        return CometRef;
    }

    // Use this for initialization
    void Awake ()
    {
        CometRef = Instantiate(CometRef);
        CometRef.name = CometRef.name.Replace("(Clone)", "").Trim();
    }
}
