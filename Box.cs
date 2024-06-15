using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Box : MonoBehaviour
{
    int count = 0;
    int countToShow = 0;
    bool isDone;
    public GameObject SuccesfulPanel;
    public GameObject ghostAtEnd;
    public GameObject screenTransition;
    public Transform spawnPos;
    private const string countKey = "count";
    GhostDialouge gD;
    public GameObject fireColum;
    public Transform pos1;
    public Transform pos2;
    public Transform pos3;
    public Transform pos4;
    public Transform pos5;
    public Transform pos6;
    public Transform pos7;
    public Transform pos8;
    public GameObject bodyPart;
    public GameObject dialougePoint15;
    QuestManagerment quest;
    public AudioSource aus;
    public AudioClip endGameSound;
    UIManager mUI;
    private void Start()
    {
        mUI = FindObjectOfType<UIManager>();
        quest = FindObjectOfType<QuestManagerment>();
        gD = FindObjectOfType<GhostDialouge>();
        count = PlayerPrefs.GetInt(countKey, 0);
        Debug.Log("Loaded Count" + count);
    }
    private void Update()
    {
        if(count > 6)
        {
            //StartCoroutine(ShowDialougeWin());
            count = 1;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Part"))
        {
            Debug.Log("Da cham");
            count++;
            Debug.Log(count);
            PlayerPrefs.SetInt(countKey, count);
            PlayerPrefs.Save();
            if (count >= 6)
            {
                isDone = true;
                Debug.Log("Nhiem vu hoan thanh");
                StartCoroutine(EndProcess());
                if(endGameSound!= null)
                {
                    aus.PlayOneShot(endGameSound);
                }
               
                
            }
            Destroy(collision.gameObject);

        }
        if(collision.CompareTag("Player"))
        {
            StartCoroutine(ShowBodyPart());


        }
    }


    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
        SuccesfulPanel.SetActive(false);

    }
    public void Next()
    {
        //
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void SpawnGhostAtEnd()
    {
        if(ghostAtEnd)
        {
            Instantiate(ghostAtEnd, spawnPos.position, Quaternion.identity);
        }
    }
    IEnumerator EndProcess()
    {
        StartCoroutine(SpawnFireColum());
        yield return new WaitForSeconds(2f);
        SpawnGhostAtEnd();
        yield return new WaitForSeconds(1f);
        gD.timeT = 1;
        yield return new WaitForSeconds(45f);
        screenTransition.SetActive(true);
        yield return new WaitForSeconds(1f);
        yield return new WaitForSeconds(0.5f);
        screenTransition.SetActive(false);
        //SuccesfulPanel.SetActive(true);
        mUI.ShowGameWin();

    }
    public void FireColum1()
    {
        if(fireColum)
        {
            Instantiate(fireColum, pos1.position, Quaternion.identity);
        }
    }
    public void FireColum2()
    {
        if (fireColum)
        {
            Instantiate(fireColum, pos2.position, Quaternion.identity);
        }
    }
    public void FireColum3()
    {
        if (fireColum)
        {
            Instantiate(fireColum, pos3.position, Quaternion.identity);
        }
    }
    public void FireColum4()
    {
        if (fireColum)
        {
            Instantiate(fireColum, pos4.position, Quaternion.identity);
        }
    }
    public void FireColum5()
    {
        if (fireColum)
        {
            Instantiate(fireColum, pos5.position, Quaternion.identity);
        }
    }
    public void FireColum6()
    {
        if (fireColum)
        {
            Instantiate(fireColum, pos6.position, Quaternion.identity);
        }
    }
    public void FireColum7()
    {
        if (fireColum)
        {
            Instantiate(fireColum, pos7.position, Quaternion.identity);
        }
    }
    public void FireColum8()
    {
        if (fireColum)
        {
            Instantiate(fireColum, pos8.position, Quaternion.identity);
        }
    }
    IEnumerator SpawnFireColum()
    {
        FireColum1();
        yield return new WaitForSeconds(0.5f);
        FireColum2();
        yield return new WaitForSeconds(0.5f);
        FireColum3();
        yield return new WaitForSeconds(0.5f);
        FireColum4();
        yield return new WaitForSeconds(0.5f);
        FireColum5();
        yield return new WaitForSeconds(0.5f);
        FireColum6();
        yield return new WaitForSeconds(0.5f);
        FireColum7();
        yield return new WaitForSeconds(0.5f);
        FireColum8();

    }
    IEnumerator ShowBodyPart()
    {
        while(countToShow < 3)
        {
            bodyPart.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            bodyPart.SetActive(false);
            yield return new WaitForSeconds(0.1f);
            bodyPart.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            bodyPart.SetActive(false);
            yield return new WaitForSeconds(0.2f);
            countToShow++;
        }
        yield return new WaitForSeconds(1f);
        dialougePoint15.SetActive(true);
        yield return new WaitForSeconds(10f);
        quest.NextQuest();

    }
}
