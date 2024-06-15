using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoneQuest : MonoBehaviour
{
    int count = 1;
    QuestManagerment quest;
    private void Start()
    {
        quest = FindObjectOfType<QuestManagerment>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(count == 1)
            {
                quest.NextQuest();
                count++;
            }
        }
    }
    

}
