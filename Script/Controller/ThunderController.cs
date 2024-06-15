using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
/*using UnityEditor.Tilemaps;*/
/*using UnityEditor.UIElements;*/
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ThunderController : MonoBehaviour
{
    public Light2D globalLight;
    private static float targetIntensity = 0.1f;
    public float changeSpeed = 10f;
    public GameObject ghost;
    public AudioSource aus;
    public AudioClip lightning;
    public AudioClip electricity;
    public AudioClip ghostSound;
    int countThunder = 0;
    public Transform spawnPos;
    BedRoomController bedroomC;
    private static int count = 0;
    Bed bed;
    Laptop laptop;
    MapManager mapM;
    void Start()
    {
        mapM = FindObjectOfType<MapManager>();
        laptop = FindObjectOfType<Laptop>();
        bed = FindObjectOfType<Bed>();  
        DontDestroyOnLoad(gameObject);
        if (globalLight != null)
        {
            globalLight.intensity = targetIntensity;
        }
        bed.stringsTimes = count;
        if(count >0)
        {
            bed.nightMareString.SetActive(true);
        }
    }

    void Update()
    {

/*        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(ShowThunder());
        }*/

    }

    public void SetIntensity(float newIntensity)
    {
        if (globalLight != null)
        {
            globalLight.intensity = newIntensity;
            targetIntensity = newIntensity; 
        }
    }
    public void SpawnGhost()
    {
        if(ghost)
        {
            if(ghostSound!= null)
            {
                aus.PlayOneShot(ghostSound);
            }
            Instantiate(ghost, spawnPos.position, Quaternion.identity);
            
        }
       
    }
    IEnumerator ShowThunder()
    {

        aus.PlayOneShot(lightning);
        yield return new WaitForSeconds(1f);
        countThunder = 0;
        SpawnGhost();
        aus.PlayOneShot(electricity);
        while (countThunder <= 3)
        {
            SetIntensity(0.015f);
            yield return new WaitForSeconds(0.2f);
            SetIntensity(1f);
            yield return new WaitForSeconds(0.05f);
            SetIntensity(0.015f);
            yield return new WaitForSeconds(0.05f);
            SetIntensity(0.1f);
            countThunder++;
        }
        SetIntensity(0.05f);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            
            count++;
            Debug.Log(count);
            if(count == 2)
            {
                Destroy(mapM.barrier);
                laptop.isError = true;
                StartCoroutine(ShowThunder());
            }
        }
    }
}
