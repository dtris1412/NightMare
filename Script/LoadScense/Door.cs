using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer sr;
    public Sprite passive, active;
    public bool canOpen = false;
    public GameObject barrier;
    void Start()
    {

        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(canOpen)
            {
                Destroy(barrier);
                sr.sprite = active;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            sr.sprite = passive;
        }
    }
}
