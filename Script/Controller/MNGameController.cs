using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MNGameController : MonoBehaviour
{
    public GameObject MNGame;
    public GameObject DialoguePanel;
    public InputField inputField;
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI ErrorText;
    public TextMeshProUGUI Question;
    public TextMeshProUGUI patternText;
    public TextMeshProUGUI valueTxt;
    public bool isCorrect = true;
    public float timeToStart = 3f;
    public string correctAnswer;
    public float timToRand = 8f;
    private bool IsDoneMNGame;
    private bool isStartMNGame;
    public bool isGameOver;
    UIManager ui;

    public int score = 0;
    public int Wrong = 0;
    public int countdownvalue = 3;


    private List<string> chosenStrings = new List<string>();

    Laptop lap;

    //CountDown
    public TextMeshProUGUI countdownTxt;
    public TextMeshProUGUI BeginText;
    void Start()
    {

        ui = FindObjectOfType<UIManager>();
        lap = FindObjectOfType<Laptop>();

        // Lắng nghe sự kiện khi nội dung của ô nhập liệu thay đổi


        inputField.onValueChanged.AddListener(delegate { CheckInput(); });

        StartCoroutine(CountDownCoroutine());

        resultText.text = "";
        BeginText.text = "";
        countdownTxt.text = "";
        ErrorText.text = "Error: ";
        Question.text = "";
        valueTxt.text = "";
        patternText.text = "";
        
        

    }
    private void Update()
    {
        if(isStartMNGame == true)
        {
            if(isGameOver == false)
            {
                timToRand -= Time.deltaTime;
            }
            if (isGameOver)
            {
                timToRand = 0;
                ui.ShowGameLose(true);
                return;
            }

            if (timToRand <= 0)
            {

                ShowString();
                timToRand = 8f;
            }
        }

        // Thiết lập sự kiện cho nút xác nhận

        CheckInput();

  
    }
    IEnumerator CountDownCoroutine()
    {
        while(!lap.isFream)
        {
            yield return null;
        }
        while (countdownvalue >= 0)
        {
            countdownTxt.text = countdownvalue.ToString();
            yield return new WaitForSeconds(1);
            countdownvalue--;

        }
        if (countdownvalue < 0)
        {
            Destroy(countdownTxt);
            BeginText.text = "Start";
            yield return new WaitForSeconds(1);
            Destroy(BeginText);
            lap.TurnOffFreamDesktopMNGame();
            isStartMNGame = true;
            StartMNGame();
        }
            
        
        



    }

    public void StartMNGame()
    {
        lap.TurnOnMNGAME();
    }

    public void CheckInput()
    {
        string colortxt = "";
        string userInput = inputField.text;
        int countWrong = 0;
        for (int i = 0; i < userInput.Length; i++)
        {
            if (i < correctAnswer.Length && userInput[i] == correctAnswer[i])
            {
                colortxt += $"<color=#00ff00>{userInput[i]}</color>";
                isCorrect = true;
            }
            else
            {
                colortxt += $"<color=#FF0000>{userInput[i]}</color>";
                countWrong++;
                isCorrect = false;
            }
    
        }
        if (isCorrect && userInput.Equals(correctAnswer, System.StringComparison.OrdinalIgnoreCase))
        {
            // Question.color = Color.green;
            score += 1;
            resultText.text = "Đáp án đúng! Điểm số: " + score;
            inputField.text = ""; // Xóa nội dung của InputField

            timToRand = 0;
            Debug.Log("Dung");
        }
        else if(!isCorrect && countWrong == 3 && !userInput.Equals(correctAnswer, System.StringComparison.OrdinalIgnoreCase))
        {
            Wrong++;
            ErrorText.text = "Error " + Wrong;
            resultText.text ="Sai! thu lai voi cau khac";
            inputField.text = "";

            timToRand = 0;
            Debug.Log("Sai");
            if(Wrong >= 3)
            {
                isGameOver = true;
            }
        }
        patternText.text = colortxt;
    }

    public string RamdomString()
    {
        System.Random rand = new System.Random();

        string[] ar = { "tieng dong", "dem nay", "hom kia","do day","tieng hat","chat thit","ky quac","la ky", "nhung ngay"
                , "am thanh", "co duoc", "am huong","thanh am", "co khong", "mot chut","vu oan", "an mang","phi cong", "tang vat"
                ,"xac chet","nguoi khac","nhu the"};

        var availableStrings = ar.Where(s => !chosenStrings.Contains(s)).ToArray();

        // Nếu không còn chuỗi nào chưa được chọn, trả về null hoặc xử lý tùy ý
        if (availableStrings.Length == 0)
        {
            isGameOver = true;
            ui.ShowGameWin(true);
            // Xử lý khi không có chuỗi nào để chọn nữa

            return null;
        }

        // Chọn một chuỗi ngẫu nhiên từ các chuỗi còn lại
        int index = rand.Next(availableStrings.Length);
        string randomString = availableStrings[index];

        // Thêm chuỗi đã chọn vào danh sách các chuỗi đã chọn
        chosenStrings.Add(randomString);

        return randomString;
    }

    public void ShowResult()
    {
        DialoguePanel.SetActive(true);
    }
    public void ShowString()
    {
        correctAnswer = RamdomString();
        Question.text = correctAnswer;
    }
    public void ShowMNGame(bool isShow)
    {
        if(MNGame != null)
        {
            MNGame.SetActive(isShow);
        }
    }

}

