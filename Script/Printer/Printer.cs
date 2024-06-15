using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Printer : MonoBehaviour
{
    SpriteRenderer sr;
    public Sprite passive, active;
    private bool canUse;
    public GameObject printerTab;
    [SerializeField] Animator anim;
    bool isPrinter = false;
    int countToNextQuest = 1;
    QuestManagerment quest;
    public bool isDoneMorse = false;
    // Start is called before the first frame update
    void Start()
    {

        sr = GetComponent<SpriteRenderer>();    
        anim = GetComponent<Animator>();
        quest = FindObjectOfType<QuestManagerment>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isPrinter && isDoneMorse)
        {
            if (canUse)
            {
                printerTab.SetActive(true);
            }
            else
                Debug.Log("Khong the mo");
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            canUse = true;
            sr.sprite = active;
            isPrinter = true;
            if(countToNextQuest == 1 && isDoneMorse)
            {
                quest.NextQuest();
                countToNextQuest++;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canUse = false;
            sr.sprite = passive;
            isPrinter = false;
        }
        
    }


}
