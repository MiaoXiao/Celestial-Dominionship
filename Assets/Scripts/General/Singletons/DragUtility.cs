using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragUtility : Singleton<DragUtility>
{
    [SerializeField]
    private AudioInfo StartDragItemSound;

    [SerializeField]
    private AudioInfo EndDragItemSound;

    /// <summary>
    /// Are we currently dragging an object?
    /// </summary>
    private bool _IsDragging = false;
    public bool IsDragging
    {
        get { return _IsDragging; }
        set { _IsDragging = false; }
    }

    /// <summary>
    /// Minimum distance allowed that an item card will lock onto a grid. Else, the card will return to its original position.
    /// BUG: Not Working
    /// </summary>
    public float MinimumDragDistance = 1000000f;

    private bool dragging;
    public Vector3 LastLocation;
    public GameObject LastParent;
    public GameObject Temp;
    public Plane Ground;
    private int LastIndex = -1;

    [HideInInspector]
    public List<GridContainer> CurrentlyActiveContainers = new List<GridContainer>();

    private void Awake()
    {
        Temp = new GameObject();
    }
    /// <summary>
    /// Dragging an object
    /// </summary>
    /// <param name="card"></param>
    public void StartDrag(GameObject card)
    {

        SoundManager.Instance.PlayAudioSource(StartDragItemSound);

        LastLocation = card.transform.position;
        LastParent = card.transform.parent.parent.gameObject;
        if (!LastParent.transform.parent.GetComponent<Grid>().Locked)
        {
            dragging = true;
            StartCoroutine(Drag(card));
        }        
        //LastContainer = card.transform.parent.parent.parent.GetComponent<GridContainer>();

       // card.transform.SetParent(UIController.Instance.transform, true);
        
    }

    IEnumerator Drag(GameObject card)
    {
        while (dragging)
        {
            Dragging(card);
            yield return null;
        }
    }

    public void Dragging(GameObject card)
    {
        Vector3 Loc;
        Ground = new Plane(Vector3.up, card.transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float rayDistance;
        if (Ground.Raycast(ray, out rayDistance))
        {
            Loc = ray.GetPoint(rayDistance);
            Loc.y = 3.0f;
            card.transform.position = Loc + new Vector3(5,0,0f);
        }
    }

    public void EndDrag(GameObject card)
    {
        dragging = false;

        SoundManager.Instance.PlayAudioSource(EndDragItemSound);

        //Current lowest distance between grid and currently held card
        float lowest_distance = MinimumDragDistance;
        card.transform.position = LastLocation;
        card.transform.SetParent(Temp.transform);
        Temp.transform.SetParent(LastParent.transform, true);
        LastParent.GetComponent<GridSlot>().Body = card.GetComponent<CelestialBody>();
        
    }

    public void CancelDrag(GameObject card)
    {

    }
}
