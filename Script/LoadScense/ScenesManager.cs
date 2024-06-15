using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScenesManager : MonoBehaviour
{
    public GameObject ScenesTransition;
    [SerializeField] Animator anim;
    void Start()
    {
        PlayStartScene();
    }
    public void LoadScenes(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void PlayStartScene()
    {
        StartCoroutine(StartScene());
    }
    public void PlayEndScene()
    {
        StartCoroutine(EndScene());
    }
    IEnumerator StartScene()
    {
        ScenesTransition.SetActive(true);
        anim.SetTrigger("Start");
        yield return new WaitForSeconds(2f);
        ScenesTransition.SetActive(false);
    }
    IEnumerator EndScene()
    {
        ScenesTransition.SetActive(true);
        anim.SetTrigger("End");
        yield return new WaitForSeconds(2f);
        ScenesTransition.SetActive(false);
    }
}
