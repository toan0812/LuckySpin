using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : GameLuckSpin
{
    [SerializeField] protected Text CurrentScore;
    public Text currentScore => CurrentScore;
    [SerializeField] protected float CurrentScoreFL;
    private SpinOff spinOff;

    private void Start()
    {
        CurrentScoreFL = float.Parse(CurrentScore.text.ToString());
        spinOff = GameObject.FindObjectOfType<SpinOff>();
    }
    private void Update()
    {       
        UpdateScore();
       
    }

    protected virtual void UpdateScore()
    {
        if(GameManager.instance.button_Handle.CanUpdateScore && GameManager.instance.button_Handle.RePlay == true)
        {
            if (spinOff.notification_gift_text.GetComponent<Text>().text.ToString() == "10" || spinOff.notification_gift_text.GetComponent<Text>().text.ToString() == "50"
                || spinOff.notification_gift_text.GetComponent<Text>().text.ToString() == "100" || spinOff.notification_gift_text.GetComponent<Text>().text.ToString() == "500"
                || spinOff.notification_gift_text.GetComponent<Text>().text.ToString() == "200" || spinOff.notification_gift_text.GetComponent<Text>().text.ToString() == "10.000"
                || spinOff.notification_gift_text.GetComponent<Text>().text.ToString() == "100.000")
            {
                CurrentScoreFL += float.Parse(spinOff.notification_gift_text.GetComponent<Text>().text.ToString());
                CurrentScore.text = CurrentScoreFL.ToString();
                GameManager.instance.button_Handle.CanUpdateScore = false;
            }          
            else if(spinOff.notification_gift_text.GetComponent<Text>().text == "X2")
            {
                CurrentScoreFL *= 2;
                CurrentScore.text = CurrentScoreFL.ToString();
                GameManager.instance.button_Handle.CanUpdateScore = false;
            }
            else if(spinOff.notification_gift_text.GetComponent<Text>().text == "X3")
            {
                CurrentScoreFL *= 3;
                CurrentScore.text = CurrentScoreFL.ToString();
                GameManager.instance.button_Handle.CanUpdateScore = false;
            }
            else if(spinOff.notification_gift_text.GetComponent<Text>().text == "X5")
            {
                CurrentScoreFL *= 5;
                CurrentScore.text = CurrentScoreFL.ToString();
                GameManager.instance.button_Handle.CanUpdateScore = false;
            }
            else if(spinOff.notification_gift_text.GetComponent<Text>().text == GiftDataController.Instance.ListData[0].GetComponent<Text>().text)
            {
                CurrentScoreFL =0;
                CurrentScore.text = CurrentScoreFL.ToString();
                GameManager.instance.button_Handle.CanUpdateScore = false;
            } 
            else if(spinOff.notification_gift_text.GetComponent<Text>().text == GiftDataController.Instance.ListData[0].GetComponent<Text>().text)
            {
                CurrentScoreFL /=2;
                CurrentScore.text = CurrentScoreFL.ToString();
                GameManager.instance.button_Handle.CanUpdateScore = false;
            }
            

        }
        if (GameManager.instance.button_Handle.RePlay == false)
        {
            CurrentScore.text = "0";
        }
    }
}
