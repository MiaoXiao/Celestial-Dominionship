using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    [SerializeField]
    private float Speed;

    public bool isActive { get; set; }

    private Vector3 Direction;

	// Use this for initialization
	void Start ()
    {
        isActive = false;
        //StartMovement(speed, direction);
    }

    public void StartMovement(float speed, Vector3 direction)
    {
        isActive = true;
        Speed = speed;
        Direction = direction;
        StartCoroutine("WaitandMove");
    }

    IEnumerator WaitandMove()
    {
        while (isActive)
        {
            transform.Translate(Speed * Direction * Time.deltaTime);
            yield return null;
        }
    }

}
