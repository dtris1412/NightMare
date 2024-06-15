using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
/*using UnityEditor.Profiling.Memory.Experimental;*/
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject DialougePoint12;
    int countToShowDialouge = 1;
    public GameObject mapPaper;
    public GameObject mapPanel;
/*    public GameObject flashLight;*/
    int count = 0;
    Paper paper;
    EnterPw ePw;
    public bool isTookMap;

    public GameObject barrier;

    bool isOpenMapPanel = false;
    bool isLightTurnOn = false;
    int countToNextQuest = 1;
    QuestManagerment quest;
    Player player;
    FlashLight fl;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(mapPanel);
        isTookMap = false;
        paper = FindObjectOfType<Paper>();
        ePw = FindObjectOfType<EnterPw>();
        quest = FindObjectOfType<QuestManagerment>();
        player = FindObjectOfType<Player>();
        fl = FindObjectOfType<FlashLight>();

    }

    // Update is called once per frame
    void Update()
    {
/*
        if (Input.GetKeyDown(KeyCode.E) && paper.canTake == true)
        {
            TakeMap();
        }*/

        if (isTookMap == true)
        {
            Destroy(barrier);
            if(Input.GetKeyDown(KeyCode.Tab))
            {
                
                Debug.Log("Co the click");
                UseMapPanel();
                if(countToShowDialouge == 1)
                {
                    DialougePoint12.SetActive(true);
                    countToShowDialouge++;
                }
            }
        }

    }
    public void UseMapPanel()
    {
        if(isOpenMapPanel == false)
        {
            mapPanel.SetActive(true);
            isOpenMapPanel = true;
            if(countToNextQuest == 1)
            {
                quest.NextQuest();
                countToNextQuest++;
            }
        }
        else
        {
            mapPanel.SetActive(false);
            isOpenMapPanel = false;
            DialougePoint12.SetActive(false);
        }
    
    }
    public void TakeMap()
    {
        mapPaper.SetActive(false);  
        isTookMap = true;
        
    }



}
