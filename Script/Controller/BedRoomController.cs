using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BedRoomController : MonoBehaviour
{
    public static int count = 0;
    public GameObject Barrier;

    private void Start()
    {
        

        if(count <= 0)
        {
            Barrier.SetActive(true);
            count++;
        }
        else
            Destroy(Barrier);
    }
}
