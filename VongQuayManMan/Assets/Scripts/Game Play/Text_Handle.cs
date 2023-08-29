using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Text_Handle : GameLuckSpin
{
    [Header("Read Data")]
   [SerializeField] protected CSVReader reader;
   [SerializeField] protected Text TextData;
   [SerializeField] protected Text Ans;
   [SerializeField] protected Text Bns;
   [SerializeField] protected Text Cns;
   [SerializeField] protected Text Dns;
   [SerializeField] protected List<string> Answers;
   [SerializeField] protected string TrueCase;
   [SerializeField] public bool IScorrect;
   [SerializeField] public bool IsWrong;
   [SerializeField] public bool CanReloadQues;
   [SerializeField] protected int index = 0;
   [SerializeField] protected int TimeLoad = 1;
   [Header("Load object")]
   [SerializeField] protected ButtonOnclick Button;
   [SerializeField] protected GameObject Notification;
   [SerializeField] protected Text InforScore;
   [SerializeField] protected GameObject Panel;
   [SerializeField] protected Score Score;

    protected override void Awake()
    {
        base.Awake();
        LoadComponent();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadButtonOnclick();
        LoadScore();
    }
    void Start()
    {
        reader = GameObject.FindObjectOfType<CSVReader>();
        LoadStartQues(0);
    }
    private void Update()
    {
        if (CanReloadQues && TimeLoad> 0)
        {
            index += 1;
            Answers.Clear();
            LoadStartQues(index);

        }
        if(TimeLoad == 0)
        {
            CanReloadQues = false;
        }
        if(GameManager.instance.button_Handle.OkHideButton == true)
        {
            TimeLoad = 1;
        }
        CheckRightAnswer();
        if (IsWrong)
        {
            Notification.SetActive(true);
        }
        if(GameManager.instance.button_Handle.RePlay == false && IsWrong == true)
        {
            Notification.SetActive(false);
            Panel.SetActive(false);
            GameManager.instance.Time_Handle.SetTimeUSe();
            GameManager.instance.Time_Handle.TimeCountdown();
            Answers.Clear();
            LoadStartQues(0);
            GameManager.instance.button_Handle.RePlay = true;

        }

    }

    protected virtual void LoadStartQues(int index)
    {
        CanReloadQues = true;
        LoadQuesTion(index);
        LoadAnswer(index);
        LoadTrueCase(index);
        LoadListAnswer(index);
        TimeLoad =0;
        IsWrong = false;
        //
    }
    protected virtual void LoadQuesTion(int index)
    {
        TextData.text = reader.quesTionList.Ques[index]._question.ToString();
    } 
    protected virtual void LoadListAnswer(int index)
    {
        Answers.Add(reader.quesTionList.Ques[index].CaseA.ToString());
        Answers.Add(reader.quesTionList.Ques[index].CaseB.ToString());
        Answers.Add(reader.quesTionList.Ques[index].CaseC.ToString());
        Answers.Add(reader.quesTionList.Ques[index].CaseD.ToString());
    }  
    protected virtual void LoadAnswer(int index)
    {
        Ans.text = reader.quesTionList.Ques[index].CaseA.ToString();
        Bns.text = reader.quesTionList.Ques[index].CaseB.ToString();
        Cns.text = reader.quesTionList.Ques[index].CaseC.ToString();
        Dns.text = reader.quesTionList.Ques[index].CaseD.ToString();
    }
    
    protected virtual void LoadTrueCase(int index)
    {
        TrueCase = reader.quesTionList.Ques[index].trueCase.ToString();
    }
    protected virtual void CheckRightAnswer()
    {
        if (GameManager.instance.Time_Handle.TimeUse == 0f && Button.obj.GetComponentInChildren<Text>().text == Answers[int.Parse(TrueCase) - 1] && Button.obj.GetComponentInChildren<Text>().text != null)
        {
            IScorrect = true;
            if (index > reader.quesTionList.Ques.Length)
            {
                Debug.Log("Win Game");
                return;
            }
                Debug.Log("Right Answer");
        }
        else if (GameManager.instance.Time_Handle.TimeUse == 0f && Button.obj.GetComponentInChildren<Text>().text != Answers[int.Parse(TrueCase) - 1] || Button.obj.GetComponentInChildren<Text>().text == null)
        {
            IScorrect = false;
            IsWrong = true;
            InforScore.text = Score.currentScore.text;
            Panel.SetActive(true);
            Debug.Log("Wrong Answer");
            return;
        }
    }
    protected virtual void LoadButtonOnclick()
    {
        if (Button != null) return;
        Button = GameObject.FindObjectOfType<ButtonOnclick>();
    }
    protected virtual void LoadScore()
    {
        if (Score != null) return;
        Score = GameObject.FindObjectOfType<Score>();
    }
}
