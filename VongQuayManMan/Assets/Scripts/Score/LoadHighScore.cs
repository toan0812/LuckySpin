using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadHighScore : MonoBehaviour
{
    public const string highScore = "Score";
    [SerializeField] protected Text LoadSCoreText;
    void Start()
    {
        LoadhighScore();
    }

    protected virtual string GetSaveName()
    {
        return highScore;
    }

    public void LoadhighScore()
    {
        string stringSave = SaveSystem.GetString(GetSaveName());
        LoadSCoreText.text = stringSave;
        Debug.Log("Load Score: " + stringSave);
    }
}

