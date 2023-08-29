using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadScore : MonoBehaviour
{
    public const string highScore = "Score";
    [SerializeField] protected Text LoadSCoreText;
    [SerializeField] Score Score;
    void Start()
    {
        Score = GameObject.FindObjectOfType<Score>();
        LoadhighScore();
    }

    protected virtual string GetSaveName()
    {
        return highScore;
    }

    public void LoadhighScore()
    {
        string stringSave = SaveSystem.GetString(GetSaveName());
        LoadSCoreText.text += "Diem: "+ stringSave;
        Debug.Log("Load Score: " + stringSave);
    }

    public virtual void SaveCore()
    {
        Debug.Log("Save!");
        string stringSave = Score.currentScore.text;
        SaveSystem.SetString(GetSaveName(),stringSave);
    }
}

