using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Time_handle : GameLuckSpin
{
    [SerializeField] protected Text TimerText;
    [SerializeField] protected float MaxTimer;
    [SerializeField] public float TimeUse;

    private void Start()
    {
        SetTimeUSe();
        TimerText.text = MaxTimer.ToString();
    }
    private void Update()
    {
        TimeCountdown();
        if (GameManager.instance.button_Handle.OkHideButton == true)
        {
            SetTimeUSe();
            TimeCountdown();
        }
    }
    public virtual void TimeCountdown()
    {   
        int MaxTimerInt = (int)(TimeUse -= Time.deltaTime);
        TimerText.text = MaxTimerInt.ToString();
        if (MaxTimerInt <= 0)
        {
            TimeUse = 0f;
        } 
    }
    public void SetTimeUSe()
    {
        TimeUse = MaxTimer;
    }

}
