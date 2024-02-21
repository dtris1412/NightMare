using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class MiniGameController : MonoBehaviour
{
    public GameObject string1;
    private float timeToSpawn;
    public TextMeshProUGUI chuoi;


    float spawnTime = 3f;
    [SerializeField] public Rigidbody2D rb1;
    String str;
    // Start is called before the first frame update
    void Start()
    {
        rb1 = GetComponent<Rigidbody2D>();
        str = FindObjectOfType<String>();
        
        
    }

    // Update is called once per frame


    private void Update()
    {
 
        timeToSpawn -= Time.deltaTime;
        if (timeToSpawn <= 0)
        {
            SpawnString1();
            timeToSpawn = spawnTime;
            Debug.Log("Spawn thanh cong");
            
        }
        


    }
    public void SpawnString1()
    {
        Vector2 SpawnPos = new Vector2(Random.Range(3f, 11f), 7f);
        if (string1)
        {
            Instantiate(string1, SpawnPos, Quaternion.identity);

        }
    }
    public void TextToDisplay(string txt)
    {
        chuoi.text = txt;
    }


}
