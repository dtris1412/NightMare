using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class MorseCharacterController : MonoBehaviour
{
    public GameObject DialougePoint;
    public string correctAnswerMorse = "BASEMENT";

    public InputField inputField;
    public TextMeshProUGUI resultText;
    public bool isCorrect = false;
    int countToNextQuest = 1;
    QuestManagerment quest;
    Printer printer;

    void Start()
    {
        printer = FindObjectOfType<Printer>();
        quest = FindObjectOfType<QuestManagerment>();

        inputField.onValueChanged.AddListener(delegate { CheckInput(); });
 
    }


    private void CheckInput()
    {
        string colortxt = "";
        string userInput = inputField.text;

        for (int i = 0; i < userInput.Length; i++)
        {
            if (i < correctAnswerMorse.Length && userInput[i] == correctAnswerMorse[i])
            {
                colortxt += $"<color=#00ff00>{userInput[i]}</color>";
                isCorrect = true;
            }
            else
            {
                colortxt += $"<color=#FF0000>{userInput[i]}</color>";
                isCorrect = false;
            }

        }

        resultText.text = colortxt; 
        isCorrect = userInput.Equals(correctAnswerMorse, System.StringComparison.OrdinalIgnoreCase);
        
    }
    public void CheckBotton()
    {
        if(isCorrect)
        {
            printer.isDoneMorse = true;

            Debug.Log("Right");
            if(countToNextQuest  == 1)
            {
                quest.NextQuest();
                countToNextQuest++;
                DialougePoint.SetActive(true);
                //tat ca cai desktop
                
            }
            
        }
        else
        {
            Debug.Log("Wrong!");
        }
    }
}
