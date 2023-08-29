using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpinOff : GameLuckSpin
{
    [Header("Speed")]
    [SerializeField] protected float Speed = 0f;
    [SerializeField] protected float slowDown = 7f;
    [SerializeField] protected float MaxSpeed = 700f;

    [Header("Spinner")]
    [SerializeField] protected Transform Spinner;
    [SerializeField] protected bool spinning;
    [SerializeField] Button SpinButton;
    [SerializeField] Color SpinColorDefault;

    [Header("Gift")]
    [SerializeField] protected GameObject Notification_gift;
    [SerializeField] protected GameObject Notification_gift_text;
    [SerializeField] protected GameObject Panel;
    public GameObject notification_gift_text => Notification_gift_text;
    SpinMarker spinMarker;

    private void Start()
    {
        SpinColorDefault = SpinButton.colors.normalColor;
        Notification_gift.SetActive(false);
        spinMarker = GameObject.FindObjectOfType<SpinMarker>();
    }
    protected void FixedUpdate()
    {
        this.Spinning();
        SpinButtonCheck();
    }

    protected virtual void SpinButtonCheck()
    {
        if(GameManager.instance.text_Handle.IScorrect == false )
        {
            SpinButton.enabled = false;
            var colors = SpinButton.colors;
            colors.normalColor = SpinColorDefault * 0.5f;
            SpinButton.colors = colors;
        }
        else
        {

            SpinButton.enabled = true;
            var colors = SpinButton.colors;
            colors.normalColor = SpinColorDefault;
            SpinButton.colors = colors;
        }
      
    }   
    protected virtual void ClaimGift()
    {
        Notification_gift.SetActive(true);
        Panel.SetActive(true);
        if(GameManager.instance.button_Handle.OkHideButton)
        {
            Notification_gift.SetActive(false);
            Panel.SetActive(false);
            MaxSpeed += 2;
            spinning = false;
        }

        Notification_gift_text.GetComponent<Text>().text = GiftDataController.Instance.ListData[int.Parse(spinMarker.spinMarkerNumber)-1].GetComponentInChildren<Text>().text;
    }
    protected void Spinning()
    {
        this.Spinner.Rotate(0,0, Time.deltaTime * this.Speed);
        this.Stoping();
    }

    public virtual void StartSpin()
    {
        this.Speed = this.MaxSpeed;
        this.spinning = true;
    }
    protected void Stoping()
    {
        if (this.spinning)
        {

            this.Speed -= this.slowDown;
            if (this.Speed < 0)
            {
                this.Speed = 0;
                ClaimGift();
                GameManager.instance.text_Handle.IScorrect = false; 
                GameManager.instance.text_Handle.CanReloadQues = true;              
                GameManager.instance.button_Handle.OkHideButton = false;
                GameManager.instance.Time_Handle.SetTimeUSe();
            }
        }
    }
}
