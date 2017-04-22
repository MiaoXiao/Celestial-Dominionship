using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class GridContainer : MonoBehaviour
{
    [SerializeField]
    protected ObjectPooler Pooler = null;

    public GameObject GridDisplay
    {
        get { return gameObject; }
    }

    /// <summary>
    /// Max amount of cards that can be stored
    /// </summary>
    public int CardMax
    {
        get
        {
            return GridDisplay.transform.childCount;
        }
    }

    private void Awake()
    {
        if (Pooler == null)
            throw new System.Exception("Grid Container must be assigned an Object Pooler.");
    }

    void Start()
    {

    }

    private void OnEnable()
    {
        //Debug.Log("enable " + name);
        DragUtility.Instance.CurrentlyActiveContainers.Add(this);
    }

    private void OnDisable()
    {
        //Debug.Log("disable " + name);
        DragUtility.Instance.CurrentlyActiveContainers.Remove(this);
    }

    /// <summary>
    /// Add physical card to grid display to next avalible spot
    /// </summary>
    public virtual void AddCard(GameObject card)
    {
        if (!CardOkay(card))
            return;

        for (int i = 0; i < GridDisplay.transform.childCount; ++i)
        {
            if (GridDisplay.transform.GetChild(i).childCount == 0)
            {
                //Debug.Log("adding " + card.name + " to index " + i);
                card.transform.SetParent(GridDisplay.transform.GetChild(i).transform);
                return;
            }
        }
        Debug.LogError("Could not add card " + card.name + " there is no more room in this container.");
    }

    /// <summary>
    /// Add physical card to grid display to specified index
    /// </summary>
    public virtual void AddCard(GameObject card, int index)
    {
        if (index < 0 || index >= CardMax)
            return;
        else if (card == null)
            return;
        else if (!CardOkay(card))
            return;

        card.transform.SetParent(GridDisplay.transform.GetChild(index));
    }

    /// <summary>
    /// Remove physical card from display.
    /// </summary>
    public virtual void RemoveCard(GameObject card)
    {
        for (int i = 0; i < GridDisplay.transform.childCount; ++i)
        {
            GameObject checked_card = GridDisplay.transform.GetChild(i).GetChild(0).gameObject;
            if (GridDisplay.transform.GetChild(i).childCount != 0 &&
                checked_card == card)
            {
                checked_card.SetActive(false);
                return;
            }
        }
        Debug.Log("Could not remove card from this GridDisplay, because the card was not found.");
    }

    /// <summary>
    /// Attempt to switch this container's card to the other container's index
    /// Returns true if switch is successful
    /// </summary>
    public void SwitchCards(int this_index, GameObject card, GridContainer container, int other_index)
    {
        //Debug.Log("from container " + this.name + " switch " + card.name + " in index " + this_index + " to container " + container.name + " at index " + other_index);
        if (!ValidIndex(this_index))
            throw new Exception("Error1");
        else if (!container.ValidIndex(other_index))
            throw new Exception("Error2");


        GameObject other_card = container.GetCardFromIndex(other_index);
        if (other_card != null) //card exists in other container
        {
            other_card.transform.SetParent(null);
            AddCard(other_card, this_index);
            container.AddCard(card, other_index);
        }
        else
        {
            container.AddCard(card, other_index);
        }
    }

    /// <summary>
    /// Returns true if this index is within range
    /// </summary>
    public bool ValidIndex(int index)
    {
        return index >= 0 && index < CardMax;
    }


    /// <summary>
    /// Return true if card can be placed in this container
    /// </summary>
    public virtual bool CardOkay(GameObject card)
    {
        return true;
    }

    /// <summary>
    /// Returns card that is located in the specified index
    /// </summary>
    public GameObject GetCardFromIndex(int index)
    {
        if (!ValidIndex(index))
            return null;
        else if (GridDisplay.transform.GetChild(index).childCount == 0)
            return null;

        return GridDisplay.transform.GetChild(index).GetChild(0).gameObject;
    }

    /// <summary>
    /// If card is found in container, return its index
    /// Otherwise, return -1
    /// </summary>
    public int GetCardIndex(GameObject card)
    {
        if (card == null)
            return -1;

        for (int i = 0; i < CardMax; ++i)
        {
            if (GridDisplay.transform.GetChild(i).childCount != 0)
            {
                if (GridDisplay.transform.GetChild(i).GetChild(0).gameObject == card)
                    return i;
            }
        }
        return -1;
    }
}
