using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    public GameObject dialougePoint4;
    public GameObject dialougePoint17;
    public int count = 0;
    int countToNextQuest = 1;
    public bool canUse = false;
    public CutScenes cs;
    public Player pl;
    public bool isDone = false;

    QuestManagerment quest;
    // Start is called before the first frame update
    void Start()
    {
        pl = FindObjectOfType<Player>();
        cs = FindObjectOfType<CutScenes>();
        quest = FindObjectOfType<QuestManagerment>();

    }

    // Update is called once per frame
    void Update()
    {
        if(count >= 3 && Input.GetKeyDown(KeyCode.E) && canUse == true)
        {
            if(cs.currentIndex == 1)
            {
                cs.PlayCutScenes();
                quest.NextQuest();
                dialougePoint4.SetActive(false);
                StartCoroutine(ShowDialouge17());
                countToNextQuest++;
            }
            return;
        }
        else if(count == 2)
        {
            if(cs.currentIndex == 0)
            {
                cs.PlayCutScenes();
                StartCoroutine(ShowDialougePoint4());
            }
            isDone = true;
            
            return;
        }

    }
    IEnumerator ShowDialougePoint4()
    {
        yield return new WaitForSeconds(2.5f);
        dialougePoint4.SetActive(true);

    }
    IEnumerator ShowDialouge17()
    {
        yield return new WaitForSeconds(1.5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {

            count++;
            canUse = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {

            canUse = false;
            dialougePoint17.SetActive(false);
            dialougePoint4.SetActive(false);
        }
    }

}
