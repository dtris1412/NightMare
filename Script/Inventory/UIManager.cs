using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject dots;
    public GameObject flashLight;
    public GameObject gameLose;
    public GameObject gameWin;
    public GameObject questmanager;
    //public GameObject ScreenTransition;

    public Image FillBar;
    public TextMeshProUGUI lifeTxt;
    public GameObject healthBar;
    //public TextMeshProUGUI valueText;
    public AudioSource aus;
    public AudioClip gameLoseSound;
    public AudioClip bottonSound;
    QuestManagerment quest;

    // Start is called before the first frame update
    void Start()
    {
        quest = FindObjectOfType<QuestManagerment>();
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(gameLose);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ShowDots(bool isShowDots)
    {
        if (dots != null)
        {
            dots.SetActive(isShowDots);
        }
    }
    public void ShowFlashLight(bool isShowFL)
    {
        if (flashLight != null)
        {
            flashLight.SetActive(isShowFL);
        }
    }
    
    public void UpdateBar(int currentValue, int maxValue)
    {
        FillBar.fillAmount = (float)currentValue / (float)maxValue;
        
    }
    public void SetLifeText(string txt2)
    {
        lifeTxt.text = txt2;
    }
    public void ShowGameLose()
    {
        if(gameLoseSound != null)
        {
            aus.PlayOneShot(gameLoseSound);
        }
        gameLose.SetActive(true);
        Destroy(healthBar);
    }
    public void ShowGameWin()
    {
        gameWin.SetActive(true);
        Destroy(healthBar);
    }
/*    IEnumerator GameLose()
    {
        ScreenTransition.SetActive(true);
        yield return new WaitForSeconds(1f);
        gameLose.SetActive(true);
        ScreenTransition.SetActive(false);
    }*/
    public void BackToMenuBotton()
    {
        if (bottonSound != null)
        {
            aus.PlayOneShot(bottonSound);
        }
        ResetGame();
        SceneManager.LoadScene(0);
        gameLose.SetActive(false);
        gameWin.SetActive(false);
        quest.ShowOffQuestPanle();
    }
    public void ResetGame()
    {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
    }
    public void QuitGame()
    {
        if (bottonSound != null)
        {
            aus.PlayOneShot(bottonSound);
        }
        Application.Quit();
    }
    public void DesTroyObject()
    {
        Destroy(healthBar);
        Destroy(questmanager);
    }

}
