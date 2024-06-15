using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Downloading : MonoBehaviour
{
    public GameObject DialougePoint7;
    public GameObject DialougePoint11;
    public GameObject DialougePoint10;
    public Image fillBar;
    public TextMeshProUGUI valueTxt;
    public TextMeshProUGUI downloadtxt;
    public GameObject winRar;
    public GameObject file;
    public GameObject openBotton;
    float maxValue = 10000;
    float currentvalue = 0;
    bool isDone = false;
    int countToNextQuest = 1;
    QuestManagerment quest;
    public GameObject transFormPassw;
    public bool isOpenedFileMorse = false;
    public bool isOpenWinrar;
    void Start()
    {
        downloadtxt.text = "Downloading";
        quest = FindObjectOfType<QuestManagerment>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Dloading());
    }
    public void UpdateDloadingBar(float currentVal, float maxVal)
    {
        fillBar.fillAmount = (float)currentVal / (float)maxVal;
        valueTxt.text = currentVal.ToString() + " kb" + " / " + maxVal.ToString() + " kb";
    }
    public IEnumerator Dloading()
    {
        while(currentvalue < maxValue)
        {
            currentvalue ++;
            UpdateDloadingBar(currentvalue, maxValue);
            yield return new WaitForSeconds(5f);
        }
        isDone = true;
        if(isDone)
        {
            downloadtxt.text = "Downloaded";
            openBotton.SetActive(true);
            
        }

    }
    public void OpenwinRarButton()
    {
        if(isOpenedFileMorse == true)
        {
            winRar.SetActive(true);
            if (countToNextQuest == 2)
            {
                quest.NextQuest();
                countToNextQuest++;
                DialougePoint10.SetActive(true);

            }
        }

        //DialougePoint10.SetActive(false);
    }
    public void QuitwinRarBotton()
    {
        
        winRar.SetActive(false);
        if(countToNextQuest == 3)
        {
            quest.NextQuest();
            countToNextQuest++;
            DialougePoint11.SetActive(true);
        }
        //DialougePoint11.SetActive(false);
    }
    public void OpenFileBotton()
    {
        isOpenedFileMorse = true;
        file.SetActive(true);
        if(countToNextQuest == 1)
        {
            quest.NextQuest();
            countToNextQuest++;
            DialougePoint7.SetActive(true);
        }
        
        //DialougePoint7.SetActive(false);

    }
    public void QuitFileBotton()
    {
        file.SetActive(false);
    }
    public void QuitTransFormPasswd()
    {
        transFormPassw.SetActive(false);
    }
}
