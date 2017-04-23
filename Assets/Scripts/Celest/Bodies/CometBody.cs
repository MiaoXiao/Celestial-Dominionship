using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CometBody : MeteorBody
{
    [SerializeField]
    private Comet CometRef = null;

    private MoveScript Mover = null;

    private bool Primed = false;

    private bool Fired = false;


    public override void OnHit(Collider collision, MeteorBody meteor_body)
    {
        print("COMET ON HIT");

        CometRef.piercing--;
        if (CometRef.piercing <= -1)
        {
            damageCelestWithinRadius();
            gameObject.SetActive(false);
        }
            

    }

    public override void Play()
    {
        if (Fired)
            return;

        if (!Mover.isActive)
        {
            Mover.StartMovement(CometRef.projectileSpeed, Vector3.right);
            Fired = true;
            StartDeathTimer(10f);
        }
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);

        if (eventData.button == PointerEventData.InputButton.Left && isLocked)
        {
            Play();
        }
            
    }

    public override Celest GetCelest()
    {
        return CometRef;
    }

    // Use this for initialization
    void OnEnable ()
    {
        CometRef = Instantiate(CometRef);
        CometRef.name = CometRef.name.Replace("(Clone)", "").Trim();

        Mover = GetComponent<MoveScript>();
        if (Mover == null)
            gameObject.AddComponent<MoveScript>();

    }
}
