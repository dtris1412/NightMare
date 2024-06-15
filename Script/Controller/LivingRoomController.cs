using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LivingRoomController : MonoBehaviour
{
    public GameObject obstacle;
    public Light2D globalLight;
    private static int count = 0;
    public GameObject bloodVfx;
    public GameObject fireVfx;
    public AudioSource aus;
    public AudioClip bloodSoud;
    public AudioClip fireSound;
    public bool canShowBloodVfx = false;
    public bool canShowFireVfx = false;
    public GameObject Barrier;
    // Start is called before the first frame update
    void Start()
    {
        if(count <= 0)
        {
            Barrier.SetActive(true);
            obstacle.SetActive(false);
            globalLight.intensity = 1;
            count++;
        }
        else
        {
            obstacle.SetActive(true);
            globalLight.intensity = 0.04f;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canShowBloodVfx == true)
        {
            StartCoroutine(ShowBloodVfx());
            canShowBloodVfx = false;
        }
        if(canShowFireVfx == true)
        {
            StartCoroutine(ShowFireVfx());
            canShowFireVfx = false;
        }
    }
    public IEnumerator ShowBloodVfx()
    {
        aus.PlayOneShot(bloodSoud);
        bloodVfx.SetActive(true);
        yield return new WaitForSeconds(1f);
        bloodVfx.SetActive(false);
    }
    public IEnumerator ShowFireVfx()
    {
        aus.PlayOneShot(fireSound);
        fireVfx.SetActive(true);
        yield return new WaitForSeconds(1f);
        fireVfx.SetActive(false);

    }

}
