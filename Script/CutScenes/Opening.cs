//using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Opening : MonoBehaviour
{
    public UnityEngine.UI.Image openingImage;
    public Sprite[] openingSprites;
    public string[] openingString;
    public TextMeshProUGUI openingTxt;
    private float timeBetweenFreams = 4.5f;
    private int currentFreamsIndex = 0;
    private int currentTxtIndex = 0;
    public AudioSource aus;
    public AudioClip[] StoryTellerVoice;
    private int currentVoiceIndex = 0;
    [SerializeField] Animator transitionAnim;

    //blood hand
    public GameObject bloodHand;
    private float timeToSpawn = 0.6f;
    public bool isSpawn = false;
    public ScenesManager sm;
    private List<GameObject> spawnedBloodHands = new List<GameObject> ();
    //Bus
    public GameObject bus;
    public Transform busSpawnPos;
    // Start is called before the first frame update
    void Start()
    {
        sm = FindObjectOfType<ScenesManager>();
        openingTxt.text = "";
        PlayOpening();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown && currentFreamsIndex == openingSprites.Length )
        {
            sm.LoadScenes(3);
        }
    }
    public void PlayOpening()
    {
        StartCoroutine(ShowOpening());
    }
    
    public void SpawnBloodHand()
    {
        Vector2 spawnPos = new Vector2(Random.Range(-5, 5), Random.Range(2.5f, -2.5f));
        if(bloodHand)
        {
            aus.PlayOneShot(StoryTellerVoice[3]);
            GameObject bloodHandsInstance = Instantiate(bloodHand, spawnPos, Quaternion.identity);
            spawnedBloodHands.Add(bloodHandsInstance);
        }
    }
    
    IEnumerator BloodHand()
    {
        
        yield return new WaitForSeconds(timeToSpawn);
        SpawnBloodHand();
    }
    public void SpawnBus()
    {
        if(bus)
        {
            Instantiate(bus, busSpawnPos.position, Quaternion.identity);
        }
    }
    
    IEnumerator ShowOpening()
    {
        foreach(Sprite sprite in openingSprites)
        {
            if(aus && StoryTellerVoice[currentVoiceIndex])
            {
                sm.ScenesTransition.SetActive(true);
                transitionAnim.SetTrigger("ReStart");
            
                openingImage.sprite = sprite;
                openingTxt.text = openingString[currentTxtIndex];
                aus.PlayOneShot(StoryTellerVoice[currentVoiceIndex]);
                if (currentVoiceIndex == 1 && currentTxtIndex == 1 && currentVoiceIndex == 1)
                {
                    
                    timeBetweenFreams = 1f;
                }
                else if(currentVoiceIndex == 3 && currentTxtIndex == 3 && currentVoiceIndex == 3 && isSpawn == false)
                {
                    
                    StartCoroutine(SpawnBloodHands());
                }
                else if(currentVoiceIndex == 9 && currentTxtIndex == 9 && currentVoiceIndex == 9)
                {
                    SpawnBus();
                }
                else
                {
                    ClearBloodHands();
                    isSpawn = false;
                    timeBetweenFreams = 4.5f;
                }
               
                currentFreamsIndex++;
                currentTxtIndex++;
                currentVoiceIndex++;
                
                yield return new WaitForSeconds(timeBetweenFreams);
            }
        }
        
        transitionAnim.SetTrigger("End");
    }
    IEnumerator SpawnBloodHands()
    {
        isSpawn = true;
        while(isSpawn)
        {
            SpawnBloodHand();
            yield return new WaitForSeconds(timeToSpawn);
            Destroy(bloodHand);
        }
    }
    void ClearBloodHands()
    {
        foreach(GameObject bloodHand in spawnedBloodHands)
        {
            Destroy(bloodHand);
        }
        spawnedBloodHands.Clear();
    }
}
