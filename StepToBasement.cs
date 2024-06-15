using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class StepToBasement : MonoBehaviour
{
    public GameObject dialougePoint13;

    int countToShowDialouge = 1;
    private static int count = 0;
    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            count++;
            if (countToShowDialouge == 1)
            {
                dialougePoint13.SetActive(true);
                countToShowDialouge++;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            dialougePoint13.SetActive(false); 
        }
    }

}
