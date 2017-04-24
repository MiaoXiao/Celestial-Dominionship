using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AsteroidBody : MeteorBody
{
    [SerializeField]
    private Asteroid AsteroidRef;

    private MoveScript Mover = null;

    private bool Fired = false;

    public override void OnHit(Collider collision, MeteorBody meteor_body)
    {
        print("ASTEROID ON HIT");

        damageCelestWithinRadius();
        gameObject.SetActive(false);
    }

    public override void Play()
    {
        if (Fired)
            return;

        if (!Mover.isActive)
        {
            transform.position += new Vector3(0, 60f, 0);
            GetComponent<Collider>().enabled = true;
            Mover.StartMovement(AsteroidRef.projectileSpeed, Vector3.down);
            Fired = true;
            StartDeathTimer(10f);
        }
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left && !isLocked)
        {
            DragUtility.Instance.EndDragForce(this.gameObject);
            Play();
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
        return AsteroidRef;
    }

    // Use this for initialization
    void OnEnable ()
    {
        AsteroidRef = Instantiate(AsteroidRef);
        AsteroidRef.name = AsteroidRef.name.Replace("(Clone)", "").Trim();

        Mover = GetComponent<MoveScript>();
        if (Mover == null)
            gameObject.AddComponent<MoveScript>();

    }
}
