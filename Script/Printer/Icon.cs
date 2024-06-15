using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;


public class Icon : MonoBehaviour
{
    public GameObject DialougePoint9;
    private int[] countBotton;
    public GameObject houseMap;
    public GameObject xx;
    public GameObject yy;
    public GameObject printer;
    public GameObject enterPasswPanel;
    [SerializeField] Animator anim;
    EnterPw enterPw;
    int countToNextQuest = 1;
    QuestManagerment quest;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        enterPw = FindObjectOfType<EnterPw>();
        quest = FindObjectOfType<QuestManagerment>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Botton1()
    {
        houseMap.SetActive(true);
        
    }
    public void Botton2()
    {
        xx.SetActive(true);
    }
    public void Botton3()
    {
        yy.SetActive(true);
    }
    public void BackBotton()
    {
        houseMap.SetActive(false);
        xx.SetActive(false);
        yy.SetActive(false);
    }
    public void ExitPrinter()
    {

        printer.SetActive(false);
    }
    public void PrintBotton()
    {
        
        enterPasswPanel.SetActive(true);
        if (countToNextQuest == 1)
        {
            quest.NextQuest();
            countToNextQuest++;
            DialougePoint9.SetActive(true);
        }
    }
    public void QuitPrinter()
    {
        printer.SetActive(false);
    }

}
