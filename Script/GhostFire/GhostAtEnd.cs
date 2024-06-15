using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAtEnd : MonoBehaviour
{
    Rigidbody2D rb;
    float speed = 4f;
    float timeToStop;
    GhostDialouge gD;
    // Start is called before the first frame update
    void Start()
    {
        timeToStop = 0.5f;
        rb = GetComponent<Rigidbody2D>();   
        gD = FindObjectOfType<GhostDialouge>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.up * speed;
        timeToStop -= Time.deltaTime;
        if(timeToStop <= 0)
        {
            speed = 0f;
        }
    }

}
