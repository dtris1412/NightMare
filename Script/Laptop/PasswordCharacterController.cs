using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PasswordCharacterController : MonoBehaviour
{
    public string correctAnswerPassword = "YWxwaGFiZXQ=";

    public InputField inputField;
    public TextMeshProUGUI resultText;
    public bool isCorrect;
    int countToNextQuest = 1;
    QuestManagerment quest;
    public GameObject dialougePoint16;
    public GameObject TransFormPassword;
    void Start()
    {
        quest = FindObjectOfType<QuestManagerment>();
        inputField.onValueChanged.AddListener(delegate { CheckInput(); });
    }


    private void CheckInput()
    {
        string colortxt = "";
        string userInput = inputField.text;

        for (int i = 0; i < userInput.Length; i++)
        {
            if (i < correctAnswerPassword.Length && userInput[i] == correctAnswerPassword[i])
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
        isCorrect = userInput.Equals(correctAnswerPassword, System.StringComparison.OrdinalIgnoreCase);

    }
    public void CheckBotton()
    {
        if (isCorrect)
        {
             //THAY BANG ANIMATION CORRECT
             Debug.Log("RIGHT");
             resultText.text = "Alphabet";
            StartCoroutine(TransPanel());
/*             if(countToNextQuest == 1)
             {
                    quest.NextQuest();
                    countToNextQuest++;
             }*/
        }
        else
        {
            Debug.Log("Wrong!");
            
        }
     }
    IEnumerator TransPanel()
    {
        yield return new WaitForSeconds(3f);
        TransFormPassword.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        dialougePoint16.SetActive(true);

    }


}
