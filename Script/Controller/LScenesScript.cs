using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LScenesScript : MonoBehaviour
{
    public AudioSource aus;
    public AudioClip bottonSound;
    public void LoadScenes(int value)
    {
        SceneManager.LoadScene(value);
    }
    public void StartBotton()
    {
        if (bottonSound != null)
        {
            aus.PlayOneShot(bottonSound);
        }
        
        LoadScenes(1);
    }
    public void OptionBotton()
    {
        if (bottonSound != null)
        {
            aus.PlayOneShot(bottonSound);
        }
    }
    public void NextSceneBotton()
    {
        if (bottonSound != null)
        {
            aus.PlayOneShot(bottonSound);
        }
        LoadScenes(2);
    }
    public void QuitGameBotton()
    {
        if (bottonSound != null)
        {
            aus.PlayOneShot(bottonSound);
        }
        Application.Quit();
    }
}
