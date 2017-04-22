using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    public CountdownTimer(int max_time)
    {
        StartingTimer = max_time;
    }

    [SerializeField]
    private int StartingTimer = 0;

    private int _CurrentTime = 0;
    public int CurrentTime
    {
        get
        {
            return _CurrentTime;
        }
        private set
        {
            if (value <= -1)
            {
                if (timerDone != null)
                    timerDone();
                return;
            }
            _CurrentTime = value;
            //Debug.Log(value);
            if (timeSet != null)
                timeSet(_CurrentTime);
        }
    }

    private float CountToSecond = 0f;

    /// <summary>
    /// Time has been altered
    /// </summary>
    public delegate void TimeSet(int seconds);
    public TimeSet timeSet;

    /// <summary>
    /// Timer hit 0
    /// </summary>
    public delegate void TimerDone();
    public TimerDone timerDone;

    public bool Paused = false;

    private void Awake()
    {

    }

    // Use this for initialization
    private void Start ()
    {
        CurrentTime = StartingTimer;
	}
	
	// Update is called once per frame
	private void Update ()
    {
        if (!Paused)
        {
            CountToSecond += Time.deltaTime;
            if (CountToSecond >= 1f)
            {
                CountToSecond = 0f;
                CurrentTime -= 1;
            }
        }
    }

    public void AddToCurrentTime(int seconds)
    {
        CurrentTime += seconds;
    }


    public void SetCurrentTime(int seconds)
    {
        CurrentTime = seconds;
    }

    public void ResetTime()
    {
        CurrentTime = StartingTimer;
        CountToSecond = 0f;
        Paused = false;
    }

}
