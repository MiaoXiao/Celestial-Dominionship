using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometBody : MeteorBody
{
    [SerializeField]
    private Comet CometRef;

    private MoveScript Mover = null;

    public override void OnHit()
    {
        throw new NotImplementedException();
    }

    public override void Play()
    {
        throw new NotImplementedException();
    }

    protected override Celest GetCelest()
    {
        return CometRef;
    }

    // Use this for initialization
    void Awake ()
    {
        CometRef = Instantiate(CometRef);
        CometRef.name = CometRef.name.Replace("(Clone)", "").Trim();

        Mover = GetComponent<MoveScript>();
        if (Mover == null)
            gameObject.AddComponent<MoveScript>();

    }
}
