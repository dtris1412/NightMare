using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class EnterPw : MonoBehaviour
{
    public string correctPw = "1496720131815";
    public InputField passwInput;
    string userInput;
    public GameObject LoadingScroll;
    public GameObject FacePrinter;
    public GameObject loadToDonePrinting;
    public GameObject paper;
    public bool isCorrect;
    public bool isMapPaper;
    Icon icon;
    int countToNextQuest = 1;
    QuestManagerment quest;
    void Start()
    {
        userInput = passwInput.text;
        passwInput.onValueChanged.AddListener(UpdatePasswordInput);
        icon = FindObjectOfType<Icon>();
        quest = FindObjectOfType<QuestManagerment>();
        isCorrect = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void UpdatePasswordInput(string input)
    {
        userInput = input;
    }

    public void CheckPasswordBotton()
    {
        if(correctPw.Equals(userInput))
        {
            Debug.Log("Correct, Let insied");
            StartCoroutine(showLoadingScrol());
            isCorrect = true;
            paper.SetActive(true);
            isMapPaper = true;
            if(countToNextQuest == 1)
            {
                quest.NextQuest();
                countToNextQuest++;
            }

        }
        else
        {
            Debug.Log("Wrong, try again!");
            passwInput.text = "";
            isCorrect = false;
        }
    }
    public IEnumerator showLoadingScrol()
    {
        LoadingScroll.SetActive(true);
        yield return new WaitForSeconds(3f);
        LoadingScroll.SetActive(false);
        icon.ExitPrinter();
        loadToDonePrinting.SetActive(true);
        yield return new WaitForSeconds(1f);
/*        paper.SetActive(true);
        Debug.Log("xxxx");*/
    
    }


}
