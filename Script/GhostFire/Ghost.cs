using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    Rigidbody2D rb;
    private float speed = 15f;
    PlayerHealth playerH;
    LivingRoomController lrC;
    void Start()
    {
        lrC = FindObjectOfType<LivingRoomController>();
        rb = GetComponent<Rigidbody2D>();
        playerH = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.right * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerH.TakeDame(20);
            lrC.canShowBloodVfx = true;
            //StartCoroutine(lrC.ShowVfx());      
            Destroy(gameObject);

        }
        else if(collision.CompareTag("ShieldLight"))
        {
            Destroy(gameObject);
        }
    }
}
