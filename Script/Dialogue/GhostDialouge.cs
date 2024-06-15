using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GhostDialouge : MonoBehaviour
{
    public GameObject dialoguePanle;
    public TextMeshProUGUI dialogueText;
    public string[] dialogue;
    /*public GameObject contBotton;*/

    private int index;
    private float wordSpeed = 0.02f;
    //public bool playerIsClose;
    public bool isRun = true;
    int count = 1;
    public bool playerIsClose = false;
    public int timeT;
    GhostAtEnd gAE;
    private void Start()
    {
        timeT = 0;
        gAE = FindObjectOfType<GhostAtEnd>();
        isRun = true;
    }
    private void Update()
    {
    

        if (isRun == true && timeT == 1)
        {
            timeT -= 1;
            if (dialoguePanle.activeInHierarchy)
            {
                ZeroText();
            }
            else
            {
                dialoguePanle.SetActive(true);
                StartCoroutine(Typing());
                StartCoroutine(AutoNextLine());
            }
        }
    }
    public void ZeroText()
    {
        dialogueText.text = "";
        index = 0;

        dialoguePanle.SetActive(false);
    }
    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }
    IEnumerator AutoNextLine()
    {
        while(true)
        {
            isRun = false;
            yield return new WaitForSeconds(7f);
            isRun = true;
            NextLine();
        }
    }
    public void NextLine()
    {
 
        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            ZeroText();
            count++;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerIsClose = false;
            ZeroText();
        }
    }


}
