using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightMareString : MonoBehaviour
{
    public GameObject DialougePoint6;
    int countToNextQuest = 1;
    QuestManagerment quest;

    void Start()
    {
        quest = FindObjectOfType<QuestManagerment>();
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(countToNextQuest == 1)
            {
                quest.NextQuest();
                countToNextQuest++;
                DialougePoint6.SetActive(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
      if(collision.CompareTag("Player"))
        {
            DialougePoint6.SetActive(false);
        }
    }
}
