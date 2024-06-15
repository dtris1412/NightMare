using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;
using System;

public class DialougeManager : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    private string fileD1 ="Assets/Dialogues1.txt";
    private string fileD2 = "Assets/Dialogues2.txt";
    private string fileD3 = "Assets/Dialogues3.txt";// Đường dẫn đến file dialogues.txt
    public GameObject contButton;
    private string[][] dialogues; // Mảng 2D cho các đoạn đối thoại
    private int dialogueIndex; 
    private int elementIndex; 
    private float wordSpeed = 0.02f;
    public bool playerIsClose;
    private int dialougeOrder;

    [System.Serializable]
    public class DialogueData
    {
        public string[] dialogueElements;
    }
    void Start()
    {
        dialougeOrder = 0;

        //ShowDialogue(0);
    }
    private void Update()
    {
        switch (dialougeOrder)
        {
            case 1:
                {
                    LoadDialogues(fileD1);
                    dialougeOrder++;
                    break;
                }
            case 2:
                {
                    LoadDialogues(fileD2);
                    break;
                }
            case 3:
                {
                    LoadDialogues(fileD3);
                    break;
                }
        }
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose == true)
        {

            if (dialoguePanel.activeInHierarchy)
            {
                ZeroText();
            }
            else
            {
                dialoguePanel.SetActive(true);

                StartCoroutine(TypeDialogue());
            }
        }
        if (elementIndex >= dialogues[dialogueIndex].Length - 1)
        {
            contButton.SetActive(true);
        }
        else
        {
            contButton.SetActive(false);
        }
    }

    public void LoadDialogues(string filePath)
    {
        string fileName = filePath;
        if (File.Exists(fileName))
        {
            string[] lines = File.ReadAllLines(fileName);
            dialogues = new string[lines.Length][];
            for (int i = 0; i < lines.Length; i++)
            {
                dialogues[i] = lines[i].Split(',');
            }
        }
        else
        {
            Debug.LogError("File not found: " + fileName);
        }
    }

    public void ShowDialogue(int index)
    {
        dialoguePanel.SetActive(true);
        dialogueIndex = index;
        elementIndex = 0;
        StartCoroutine(TypeDialogue());
    }
    IEnumerator TypeDialogue()
    {
        foreach (char letter in dialogues[dialogueIndex][elementIndex].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }
    public void NextElement()
    {
        elementIndex++;
        if (elementIndex < dialogues[dialogueIndex].Length)
        {
            dialogueText.text = "";
            StartCoroutine(TypeDialogue());
        }
        else
        {
            contButton.SetActive(true);
        }
    }
    public void NextDialogue()
    {
        contButton.SetActive(false);
        elementIndex = 0; // Thiết lập lại elementIndex
        dialogueIndex++;
        if (dialogueIndex >= dialogues.Length) // Kiểm tra dialogues[dialogueIndex] có tồn tại không
        {
            dialoguePanel.SetActive(false);
        }
        else
        {
            dialogueText.text = "";
            StartCoroutine(TypeDialogue());
        }
    }
    public void ZeroText()
    {
        dialogueText.text = "";
        dialogueIndex = 0;
        elementIndex = 0;
        dialoguePanel.SetActive(false);

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
            dialoguePanel.SetActive(false);
        }
    }
}
