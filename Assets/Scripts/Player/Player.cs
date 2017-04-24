using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Note: when changing current hand, you also need to change the Grid associated with that hand
    public List<CelestialBody> CurrentHand = new List<CelestialBody>();
    public List<CelestialBody> MainDeck = new List<CelestialBody>();
    public List<CelestialBody> DiscardDeck = new List<CelestialBody>();
    public Grid Field;
    public Grid Discard;
    public Grid Hand;

    private int _Dust = 0;
    public int Dust
    {
        get
        {
            return _Dust;
        }
        set
        {
            if (value < 0)
                _Dust = 0;
            else
                _Dust = value;

            //update ui here with UIController.Instance.UpdateUI()
        }
    }
    private int BaseBuys = 1;
    private int _Buys = 1;
    public int Buys
    {
        get
        {
            return _Buys;
        }
        set
        {
            if (value < 0)
                _Buys = 0;
            else
                _Buys = value;

            //update ui here with UIController.Instance.UpdateUI()
        }
    }
    private int _cardDraw = 5;
    public int cardDraw
    {
        get
        {
            return _cardDraw;
        }
        set
        {
            if (value < 0)
                _cardDraw = 0;
            else
                _cardDraw = value;

            //update ui here with UIController.Instance.UpdateUI()
        }
    }

    private int _sunsLeft = 3;
    public int sunsLeft
    {
        get { return _sunsLeft; }
        set
        {
            _sunsLeft = value;
            if (sunsLeft <= 0)
                GameManager.Instance.WinGame(GameManager.Instance.OppositePlayer);
                
        }
    }

    public delegate void Passives();
    public Passives perTick;

    /// <summary>
    /// Draw specified number of cards into your hand up until your card draw.
    /// Shuffle discard back into Main deck if neccesary
    /// </summary>
    public void Draw(int cards)
    {
        int drawnCards = cards;
        while (drawnCards > 0)
        {
            if (MainDeck.Count == 0)
            {
                RemakeDeck();
            }
            CurrentHand.Add(MainDeck[0]);
            Hand.PopulateGrid(MainDeck[0]);
            MainDeck.RemoveAt(0);
            drawnCards--;
        }
    }

    /// <summary>
    /// Put discard pile back into main deck
    /// </summary>
    public void RemakeDeck()
    {
        if (MainDeck.Count != 0)
            return;

        MainDeck = new List<CelestialBody>(DiscardDeck);
        DeckShuffle(ref MainDeck);

    }

    /// <summary>
    /// Empty your current hand
    /// </summary>
    public void EmptyHand()
    {
        foreach(CelestialBody x in CurrentHand)
        {
            DiscardDeck.Add(x);
        }
        CurrentHand.Clear();
    }

    /// <summary>
    /// Shuffle a specified deck
    /// </summary>
    /// <param name="list"></param>
    public void DeckShuffle(ref List<CelestialBody> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            CelestialBody temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    public void SetActive()
    {

    }
    public void ResetBuys()
    {
        Buys = BaseBuys;
    }
}
