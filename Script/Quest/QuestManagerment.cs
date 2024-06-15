using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestManagerment : MonoBehaviour
{
    public GameObject QuestPanel;
    public TextMeshProUGUI questText; 
    private List<string> quests = new List<string>(); // Danh sách các nhiệm vụ
    private int currentQuestIndex = -1;
    private int lastQuestIndex;

    void Start()
    {

        DontDestroyOnLoad(gameObject);

        quests.Add("Nhan chia khoa tu chu nha");
        quests.Add("Di vao nha");
        quests.Add("Di den phong ngu");
        quests.Add("Tim cong tat den va bat len sau do ngoi vao may luyen go phim");
        quests.Add("Kiem tra lai voi nuoc trong nha tam");
        quests.Add("Kiem tra lai guong");
        quests.Add("Tien den giuong de di ngu");
        quests.Add("Tien vao nha ve sinh de rua mat");
        quests.Add("Co thong bao moi tu laptop, hay kiem tra");
        quests.Add("Hay gia ma morse do");
        quests.Add("Di tim thu gi do trong phong nay");
        quests.Add("Thu lam gi do trong xem nao");
        quests.Add("Quay lai file Winrar trong laptop de tim mat khau");
        quests.Add("Giai ma no");
        quests.Add("Quay lai may in");
        quests.Add("1497820131185");
        quests.Add("Nhat manh giay bi roi xuong va kiem tra no (Tab)");
        quests.Add("Tim chiec den pin va loi vao duoc giau trong phong ( xem ban do )");
        //3 nhiệm vụ chưa được thiết kế lối chơi
        quests.Add("Kiem tra can phong do");
        quests.Add("Tim kiem theo thu tu trong ban do va mang ve tang ham | Su dung Den pin (E) , nhat do vat (G)");
        
      
        // Hiển thị nhiệm vụ đầu tiên khi bắt đầu game
        ShowQuestPanel();
    }

    void ShowQuestPanel()
    {
        QuestPanel.SetActive(true);
        SetCurrentQuest(lastQuestIndex);
    }
    public void ShowOffQuestPanle()
    {
        QuestPanel.SetActive(false);
    }
    void SetCurrentQuest(int index)
    {
        // Kiểm tra xem chỉ số nhiệm vụ hợp lệ hay không
        if (index >= 0 && index < quests.Count)
        {
            currentQuestIndex = index;
            questText.text = quests[currentQuestIndex];
        }
    }
    public void NextQuest()
    {
        SetCurrentQuest(currentQuestIndex + 1);
    }
    public void PreviousQuest()
    {
        SetCurrentQuest(currentQuestIndex - 1);
    }
    public void SaveCurrentQuestIndex()
    {
        lastQuestIndex = currentQuestIndex;
    }
}