using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bed : MonoBehaviour
{
    public GameObject DialougePoint5;
    public GameObject ScenesTransition;
    public GameObject nightMareString;
    SpriteRenderer sr;
    public Sprite active, passive;
    public bool canUse = false;
    int countToNextQuest = 1;
    public AudioSource aus;
    public AudioClip moveDoor, closed;
    public bool isDoneSleep = false;
    public int stringsTimes = 0;
    [SerializeField] Animator anim;
    ScenesManager sm;
    QuestManagerment quest;
    Mirror mr;
    
    private void Start()
    { 
        if(stringsTimes > 0)
        {
            nightMareString.SetActive(true);
        }
        mr = FindObjectOfType<Mirror>();
        sr = GetComponent<SpriteRenderer>();
        sm = FindObjectOfType<ScenesManager>();
        quest = FindObjectOfType<QuestManagerment>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && canUse && mr.isDone == true)
        {
            PlaySleepScenes();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            sr.sprite = active;
            canUse = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            sr.sprite = passive;
            canUse = false;
        }
    }
    public void PlaySleepScenes()
    {
        StartCoroutine(ShowSleep());
    }
    IEnumerator ShowSleep()
    {
        if(aus)
        {
            ScenesTransition.SetActive(true);
            anim.SetTrigger("End");
            /*yield return new WaitForSeconds(1f);
            aus.PlayOneShot(stepFoot);*/
            yield return new WaitForSeconds(2f);
            aus.PlayOneShot(moveDoor);
            yield return new WaitForSeconds(9.5f);
            aus.PlayOneShot(closed);
            yield return new WaitForSeconds(1f);
            ScenesTransition.SetActive(false);
            nightMareString.SetActive(true);
            if (countToNextQuest == 1)
            {
                quest.NextQuest();
                
                DialougePoint5.SetActive(true);
                countToNextQuest++;
            }
        }

        isDoneSleep = true;
    }

}
