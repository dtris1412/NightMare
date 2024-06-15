using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostAttackController : MonoBehaviour
{
    int countDown = 3;
    public float timeToStart = 15f;
    public AudioSource aus;
    public AudioClip tictac;
    public AudioClip ghostSound;
    public GameObject ghost;
    public Transform spawnPos;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeToStart -= Time.deltaTime;
        if(timeToStart <= 0) 
        {
            StartCoroutine(RunCountDown());
            timeToStart = 15f;  
        }
        
    }
    public void SpawnGhost()
    {
        if(ghost)
        {
            Instantiate(ghost, spawnPos.position, Quaternion.identity);
            aus.PlayOneShot(ghostSound);
        }
    }
    public void CountDown()
    {
        countDown--;
        aus.PlayOneShot(tictac);
    }
    IEnumerator RunCountDown()
    {
        while(countDown > 0)
        {
            CountDown();
            yield return new WaitForSeconds(1f);
        }
        if(countDown == 0)
        {
            SpawnGhost();
        }
        countDown = 3;
    }
}
