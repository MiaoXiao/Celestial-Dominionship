using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBody : CelestialBody
{

    //Information of the SpecialBody
    [SerializeField]
    private Special SpecialRef;

    public override Celest GetCelest()
    {
        return SpecialRef;
    }

    private void OnEnable()
    {
        SpecialRef = Instantiate(SpecialRef);
        SpecialRef.name = SpecialRef.name.Replace("(Clone)", "").Trim();
    }

    public override void OnHit(Collider collision)
    {
        MeteorBody meteor_body = collision.gameObject.GetComponent<MeteorBody>();
        if (meteor_body == null)
            return;
    }

    //When the card is played
    public override void Play()
    {
        Activate.Instance.ActivateSpecialEffect(SpecialRef, GameManager.Instance.CurrentPlayer);
    }

}
