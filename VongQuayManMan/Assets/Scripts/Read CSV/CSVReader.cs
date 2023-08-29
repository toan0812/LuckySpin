using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;

public class CSVReader : MonoBehaviour
{
    public TextAsset TextAssetData;
    [System.Serializable]
    public class QuesTion
    {
        public string _question;
        public string id;
        public string CaseA;
        public string CaseB;
        public string CaseC;
        public string CaseD;
        public string trueCase;

    }
    [System.Serializable]
    public class QuesTionList
    {
     public QuesTion[] Ques;
    }

    public QuesTionList quesTionList = new QuesTionList();

    private void Awake()
    {
        ReadData();
    }

    void ReadData()
    {
        //string[] data = TextAssetData.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);
        string[] separators = { ",", "\n" };
        string[] data = Regex.Split(TextAssetData.text, string.Join("|", separators));
        int TableSize = data.Length/7-1;
        quesTionList.Ques = new QuesTion[TableSize];
        for(int i =0; i< TableSize;i++)
        {
            quesTionList.Ques[i] = new QuesTion();
            quesTionList.Ques[i]._question = data[7 * (i + 1)];
            quesTionList.Ques[i].id = data[7 * (i + 1)+1];
            quesTionList.Ques[i].CaseA = data[7 * (i + 1)+2];
            quesTionList.Ques[i].CaseB = data[7 * (i + 1)+3];
            quesTionList.Ques[i].CaseC = data[7 * (i + 1)+4];
            quesTionList.Ques[i].CaseD = data[7 * (i + 1)+5];
            quesTionList.Ques[i].trueCase = data[7 * (i + 1)+6];

        }
        
    }


}
