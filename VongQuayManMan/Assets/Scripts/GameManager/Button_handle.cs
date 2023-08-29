
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_handle : GameLuckSpin
{
    [SerializeField] GameManager Manager;
    [SerializeField] public bool CanUpdateScore;
    [SerializeField] public bool OkHideButton = false;
    [SerializeField] public bool OKHied = true;
    [SerializeField] public bool RePlay = true;
    [SerializeField] public Score score;
    int index = 0;
    protected override void Reset()
    {
        base.Reset();
        LoadComponent();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadGameManger();
    }

    public void Button_Exit(string name)
    {
        foreach(GameObject GameObject in Manager.ButtonObject)
        {
            if(GameObject.name == name)
            {
                GameObject.SetActive(true);
            }
        }
    }
    public void LoadNameButton(Button button)
    {
        
        Debug.Log("Load Successfull" + button.name);
    }    
    public void LoadInforButton(Text buttonText)
    {
        
        Debug.Log("Load Successfull" + buttonText.text);
    }

    public void BtnOk()
    {
        CanUpdateScore = true;
        OKHied = true;
        if (OKHied == true)
        {
            OkHideButton = true;
        }
    }
   public void BtnCancel()
    {
        RePlay = false;
        score.currentScore.text = "0";
    }

    protected virtual void LoadGameManger()
    {
        if (Manager != null) return;
        Manager = GetComponentInParent<GameManager>();
        Debug.Log(Manager.name);
    } 
  
}
