using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPlanet : MonoBehaviour {

    static Plane XZPlane = new Plane(Vector3.up, Vector3.zero);

    public bool Selected = false;

    [SerializeField]
    private Vector2 GridDimensions = Vector2.one;

    public static Vector3 GetMousePositionOnXZPlane()
    {
        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (XZPlane.Raycast(ray, out distance))
        {
            Vector3 hit_point = ray.GetPoint(distance+10);
            //Just double check to ensure the y position is exactly zero
            hit_point.y = 0;
            return hit_point;
        }
        return Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (Selected)
        {
            if (Input.GetMouseButtonDown(0))
                Selected = false;
            transform.position = GetMousePositionOnXZPlane();
        }
        else if (!Selected && Input.GetMouseButtonDown(0))
        {
//################## THIS SHOULD GO INTO AN INPUT MANAGER THINGY ##############################
            //Get a ray from the Mouse to the game world
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            // See if a raycast in the mouse's ray's direction hits an object
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Planet")
                {
                    //hit.transform.gameObject.GetComponent<ShieldPlanet>().Selected = true;
                    Selected = true;
                }
            }
//##############################################################################################

        }
        
    }

}
