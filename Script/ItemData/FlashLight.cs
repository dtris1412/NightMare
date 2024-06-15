using System.Collections;
using System.Collections.Generic;
/*using UnityEditor.PackageManager;*/
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public bool isTake = false;
    private static int count = 0;
    public static bool isTook = false;
    Player player;
    private void Start()
    {
        player = FindObjectOfType<Player>();
        if(count <= 1)
        {
            gameObject.SetActive(true);
            count++;
        }
        else
            gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.canUseFL = true;

            Destroy(gameObject);
        }

    }
}
