using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveHighScore : MonoBehaviour
{
    public const string highScore = "Score";
    [SerializeField] Score Score;
    void Start()
    {
        Score = GameObject.FindObjectOfType<Score>();

    }

    protected virtual string GetSaveName()
    {
        return highScore;
    }

    public virtual void SaveCore()
    {
        Debug.Log("Save!");
        string stringSave = Score.currentScore.text;
        SaveSystem.SetString(GetSaveName(), stringSave);
    }
}

