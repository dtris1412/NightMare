using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMiniGController : MonoBehaviour
{
    public GameObject mnGameWin;
    public GameObject mnGameLose;
    public void ShowGameLose(bool isShowGL)
    {
        mnGameLose.SetActive(isShowGL);
    }
    public void ShowGameWin(bool isShowGW)
    {
        mnGameWin.SetActive(isShowGW);
    }
}
