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

    private GridContainer LastContainer = null;
    private int LastIndex = -1;

    [HideInInspector]
    public List<GridContainer> CurrentlyActiveContainers = new List<GridContainer>();

    public void StartDrag(GameObject card)
    {

        SoundManager.Instance.PlayAudioSource(StartDragItemSound);

        LastContainer = card.transform.GetComponentInParent<GridContainer>();
        //LastContainer = card.transform.parent.parent.parent.GetComponent<GridContainer>();
        LastIndex = LastContainer.GetCardIndex(card);

        card.transform.SetParent(UIController.Instance.transform);
        
    }

    public void Dragging(GameObject card)
    {
        card.transform.position = Input.mousePosition;
        
    }

    public void EndDrag(GameObject card)
    {
        SoundManager.Instance.PlayAudioSource(EndDragItemSound);

        //Current lowest distance between grid and currently held card
        float lowest_distance = MinimumDragDistance;

        GridContainer container_final = null;

        int new_index = -1;
        //Check all active containers to detect where item should be placed
        foreach (GridContainer container in CurrentlyActiveContainers)
        {
            for (int i = 0; i < container.CardMax; ++i)
            {
                //print("iterating " + i);
                GameObject grid_space = container.GridDisplay.transform.GetChild(i).gameObject;
                float curr_lowest = Vector2.Distance(grid_space.transform.position, card.transform.position);
                if (curr_lowest < lowest_distance)
                {
                    lowest_distance = curr_lowest;
                    container_final = container;
                    new_index = i;
                    //Debug.Log("set as new index: " + new_index);
                }
            }
        }

        if (new_index != -1 && container_final.CardOkay(card))
        {
            LastContainer.SwitchCards(LastIndex, card, container_final, new_index);   
        }
        else
        {
            LastContainer.AddCard(card, LastIndex);
        }
    }
}
