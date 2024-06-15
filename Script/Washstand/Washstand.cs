using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Washstand : MonoBehaviour
{
    public GameObject waterfall;
    public bool isTurnOff;
    public bool canUse;
    public int count;
    int countToNextQuest = 1;
    public AudioSource aus;
    public AudioClip waterfallSound;
    MNGameController mn_gc;
    QuestManagerment quest;
    public Sprite active, passive;
    SpriteRenderer sr;
    public GameObject E;
    void Start()
    {
        count = 1;
        isTurnOff = true;
        mn_gc = FindObjectOfType< MNGameController>();
        quest = FindObjectOfType< QuestManagerment>();
        sr = GetComponent< SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (mn_gc.IsDoneMNGame == true && isTurnOff == true && count == 1)
        {
            TurnOnHandwashing();
            count++;
        }
        if (Input.GetKeyDown(KeyCode.E) && canUse && count >= 2 )
        {
            TurnOnAndOffHandwashing();
            if(countToNextQuest == 1)
            {
                quest.NextQuest();
                countToNextQuest++;
            }
        }
    }
    public void TurnOnAndOffHandwashing()
    {
        if(waterfall && isTurnOff && aus && waterfallSound )
        {
            aus.PlayOneShot(waterfallSound);
            waterfall.SetActive(true);
            isTurnOff = false;
        }
        else
        {
            aus.Stop();
            waterfall.SetActive(false);
            isTurnOff = true;

        }
    }
    public void TurnOnHandwashing()
    {
        if (waterfall && isTurnOff && aus && waterfallSound)
        {
            aus.PlayOneShot(waterfallSound);
            waterfall.SetActive(true);
            isTurnOff = false;
        }
    }
    
/*    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            E.SetActive(true);
            sr.sprite = active;
            canUse = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            E.SetActive(false);
            sr.sprite = passive;
            canUse = false;
        }
    }*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            E.SetActive(true);
            sr.sprite = active;
            canUse = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            E.SetActive(false);
            sr.sprite = passive;
            canUse = false;
        }
    }
}
