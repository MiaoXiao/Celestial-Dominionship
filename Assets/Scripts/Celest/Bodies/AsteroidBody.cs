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
            owner.Dust -= AsteroidRef.playCost;

            transform.position += new Vector3(0, 60f, 0);
            GetComponent<Collider>().enabled = true;
            Mover.StartMovement(AsteroidRef.projectileSpeed, Vector3.down);
            Fired = true;
            StartDeathTimer(10f);
        }
    }


    public override void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("Hit");
        if (owner == null)
        {
            Buy();
            return;
        }

        if (owner != GameManager.Instance.CurrentPlayer)
            return;

        if (owner.Dust < AsteroidRef.playCost)
        {
            return;
        }

        else if (eventData.button == PointerEventData.InputButton.Left && !isLocked)
        {
            gameObject.GetComponent<Collider>().enabled = false;
            DragUtility.Instance.StartDrag(this.gameObject);
        }

        /*
        if (eventData.button == PointerEventData.InputButton.Left && isLocked)
        {
            Play();
        }
          */  
    }


    public override void OnPointerUp(PointerEventData eventData)
    {
        if (owner == null)
            return;

        /*
        if (owner.Dust < AsteroidRef.playCost)
        {
            return;
        }
        */
        DragUtility.Instance.EndDragForce(gameObject);
        Play();
        
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
