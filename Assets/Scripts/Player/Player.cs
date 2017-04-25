using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //Note: when changing current hand, you also need to change the Grid associated with that hand
    public List<CelestialBody> CurrentHand = new List<CelestialBody>();
    public List<CelestialBody> MainDeck = new List<CelestialBody>();
    public List<CelestialBody> DiscardDeck = new List<CelestialBody>();
    public Grid Field;
    public Grid Hand;

    public Vector2 FiringDirection = Vector2.up;

    private GameObject PrimaryDisplay = null;

    public Vector3 DiscardArea = new Vector3(0, 1000, 0);
    public Vector3 DeckArea = new Vector3(0, 2000, 0);

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
            Debug.Log(_Dust);
            //update ui here with UIController.Instance.UpdateUI()
            UIController.Instance.UpdateUI(PrimaryDisplay.transform.FindChild("Dust").GetComponentInChildren<Text>(), _Dust.ToString());
        }
    }
    private int _BaseBuys = 1;
    public int BaseBuys
    {
        get { return _BaseBuys; }
        set
        {
            if (value < 1)
                _BaseBuys = 1;
            else
                _BaseBuys = value;

            //update ui here with UIController.Instance.UpdateUI()
            UIController.Instance.UpdateUI(PrimaryDisplay.transform.FindChild("Wormholes").GetComponentInChildren<Text>(), Buys.ToString() + "/" + _BaseBuys.ToString());
        }
    }
    
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
            UIController.Instance.UpdateUI(PrimaryDisplay.transform.FindChild("Wormholes").GetComponentInChildren<Text>(), _Buys.ToString() + "/" + BaseBuys.ToString());
        }
    }
    private int _cardDraw = 3;
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
            else if (value > 8)
                _cardDraw = 8;
            else
                _cardDraw = value;

            //update ui here with UIController.Instance.UpdateUI()
            UIController.Instance.UpdateUI(PrimaryDisplay.transform.FindChild("Transports").GetComponentInChildren<Text>(), _cardDraw.ToString());
        }
    }

    private int _sunsLeft = 1;
    public int sunsLeft
    {
        get { return _sunsLeft; }
        set
        {
            _sunsLeft = value;
            print("suns left " + value);
            if (_sunsLeft <= 0)
                GameManager.Instance.WinGame(GameManager.Instance.OppositePlayer);
                
        }
    }

    public delegate void Passives();
    public Passives perTick;

    private void Awake()
    {
        PrimaryDisplay = GameObject.FindGameObjectWithTag("Primary UI");
        if (PrimaryDisplay == null)
            throw new System.Exception("Please place Primary UI into the Main Canvas.");
    }

    public void DiscardCard(CelestialBody card)
    {
        DiscardDeck.Add(card);
        card.gameObject.transform.position = DiscardArea;
        card.GetComponent<Collider>().enabled = false;
    }

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
            
            if (MainDeck.Count != 0)
            {
                //Create copy to hand
                CelestialBody Temp = Instantiate<CelestialBody>(MainDeck[0]);
                Temp.gameObject.GetComponent<Collider>().enabled = true;
                Hand.PopulateGrid(Temp);
                CurrentHand.Add(Temp);

                DiscardDeck.Add(MainDeck[0]);
                MainDeck[0].GetComponent<Collider>().enabled = false;
                MainDeck[0].transform.position = DiscardArea;

                //Discard.PopulateGrid(MainDeck[0]);



                MainDeck.RemoveAt(0);

                drawnCards--;
            }

        }

        UpdateDecksizeUI();
    }

    /// <summary>
    /// Put discard pile back into main deck
    /// </summary>
    public void RemakeDeck()
    {
        if (MainDeck.Count != 0)
            return;

        MainDeck = new List<CelestialBody>(DiscardDeck);
        DiscardDeck = new List<CelestialBody>();
        foreach (CelestialBody main_card in MainDeck)
        {
            if (main_card != null)
            {
                main_card.gameObject.GetComponent<Collider>().enabled = false;
                main_card.gameObject.transform.position = DeckArea;
            }
        }
        DeckShuffle(ref MainDeck);

        UpdateDecksizeUI();
    }

    /// <summary>
    /// Empty your current hand
    /// </summary>
    public void EmptyHand()
    {
        foreach(CelestialBody x in CurrentHand)
        {
            if (x != null && !x.isLocked)
                Destroy(x.gameObject);
            //DiscardDeck.Add(x);
        }
        CurrentHand.Clear();

        UpdateDecksizeUI();
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

    public void ResetBuys()
    {
        Buys = BaseBuys;
    }

    public void UpdateDecksizeUI()
    {
        UIController.Instance.UpdateUI(PrimaryDisplay.transform.FindChild("Universe").GetComponentInChildren<Text>(), MainDeck.Count.ToString());
        UIController.Instance.UpdateUI(PrimaryDisplay.transform.FindChild("Void").GetComponentInChildren<Text>(), DiscardDeck.Count.ToString());
    }
}
