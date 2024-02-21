using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public GameObject dialoguePanle;
    public TextMeshProUGUI dialogueText;
    public string[] dialogue;

    public AudioSource aus;
    public AudioSource keyBoar;
    public GameObject contBotton;

    private int index;
    private float wordSpeed = 0.05f;
    public bool playerIsClose;


 
    public void Awake()
    {
        
        if (playerIsClose == true)
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
    }

    private void Update()
    {
        if (dialogueText.text == dialogue[index])
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
        if (index < dialogue.Length - 1)
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
