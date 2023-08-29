using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : GameLuckSpin
{
    public static GameManager instance;
    [SerializeField] public List<GameObject> ButtonObject;
    [SerializeField] protected  Time_handle time_Handle;
    public Time_handle Time_Handle => time_Handle;
    [SerializeField] protected Button_handle Button_Handle;
    public Button_handle button_Handle => Button_Handle;   
    [SerializeField] protected Text_Handle Text_Handle;
    public Text_Handle text_Handle => Text_Handle;
    protected override void Awake()
    {
        instance = this;
        LoadComponent();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        Loadtime_Handle();
        LoadButton_Handle();
        LoadText_Handle();
    }

    protected virtual void Loadtime_Handle()
    {
        if (time_Handle != null) return;
        time_Handle = GameObject.FindObjectOfType<Time_handle>();
    } 
    protected virtual void LoadButton_Handle()
    {
        if (Button_Handle != null) return;
        Button_Handle = GameObject.FindObjectOfType<Button_handle>();
    }
    protected virtual void LoadText_Handle()
    {
        if (Text_Handle != null) return;
        Text_Handle = GameObject.FindObjectOfType<Text_Handle>();
    }



}
