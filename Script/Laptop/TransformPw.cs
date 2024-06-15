using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class TransformPw : MonoBehaviour
{
    public InputField inputField;
    public TextMeshProUGUI Numbers;
    public string correctNumbers = "1497820131185";
    public GameObject dialougePoint11;
    QuestManagerment quest;
    public TextMeshProUGUI txt;
    int countToNextQuest = 1;
    private void Start()
    {
        txt.text = "";
        Numbers.text = "output";
        inputField.onValueChanged.AddListener(delegate { ConvertAlphabetNumber(); });
        quest = FindObjectOfType<QuestManagerment>();
    }
    public void ConvertAlphabetNumber()
    {
        string input = inputField.text.ToLower();
        string result = "";

        foreach (char c in input)
        {
            if (c >= 'a' && c <= 'z')
            {
                int pos = c - 'a' + 1;
                result += pos.ToString();
                        
            }   
        }
        Numbers.text = result.Trim();
    }

    public void CheckNumbersBotton()
    {
        if (Numbers.text.Equals(correctNumbers))
        {
            Debug.Log("Right");
            Debug.Log(Numbers.text);
            txt.text = "Correct!";
            CopyPassw();
            dialougePoint11.SetActive(true);
            if(countToNextQuest  == 1)
            {
                quest.NextQuest();
                countToNextQuest++;
            }
           
            
        }
        else
            Debug.Log("Wrong");
    }
    public string CopyPassw()
    {
        string passwCopied;
        passwCopied = Numbers.text;
        Debug.Log("Da copy");
        return passwCopied;
    }
    public void PasteBotton(ref InputField text)
    {
        string copiedPassword = CopyPassw();
        if (!string.IsNullOrEmpty(copiedPassword))
        {
            text.text = copiedPassword;
            Debug.Log(text.text);
        }
    }

}
