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
        //LastContainer = card.transform.parent.parent.parent.GetComponent<GridContainer>();

       // card.transform.SetParent(UIController.Instance.transform, true);
        
    }

    public void Dragging(GameObject card)
    {
        Ground = new Plane(Vector3.up, card.transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float rayDistance;
        if (Ground.Raycast(ray, out rayDistance))
        {
            Debug.Log(rayDistance);
            Debug.Log(ray.GetPoint(rayDistance));
            card.transform.position = ray.GetPoint(rayDistance) + new Vector3(5,0,0);
        }
    }

    public void EndDrag(GameObject card)
    {
        SoundManager.Instance.PlayAudioSource(EndDragItemSound);

        //Current lowest distance between grid and currently held card
        float lowest_distance = MinimumDragDistance;
        card.transform.position = LastLocation;
        card.transform.SetParent(Temp.transform);
        Temp.transform.SetParent(LastParent.transform, true);
        
    }

    public void CancelDrag(GameObject card)
    {

    }
}
