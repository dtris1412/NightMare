using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlueFire : MonoBehaviour
{
    PlayerHealth playerH;
    LivingRoomController lrC;
    void Start()
    {
        lrC = FindObjectOfType<LivingRoomController>();
        playerH = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerH.TakeDame(10);
            lrC.canShowFireVfx = true;
        }
    }
}
