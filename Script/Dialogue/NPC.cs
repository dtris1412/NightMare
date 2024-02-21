using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class NPC : MonoBehaviour
{
    public GameObject dialoguePanle;
    public TextMeshProUGUI dialogueText;
    public string[] dialogue;

    public GameObject contBotton;

    private int index;
    private float wordSpeed = 0.02f;
    public bool playerIsClose;
    

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerIsClose == true)
        {

            if (dialoguePanle.activeInHierarchy)
            {
                ZeroText();
            }
            else
            { 
                dialoguePanle.SetActive(true);
                
                StartCoroutine(Typing());
            }
        }
        if(dialogueText.text == dialogue[index])
        {
            contBotton.SetActive(true);
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
    public void NextLine()
    {
        contBotton.SetActive(false);
        if(index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            ZeroText();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            playerIsClose = false;
            ZeroText();
        }
    }


}
