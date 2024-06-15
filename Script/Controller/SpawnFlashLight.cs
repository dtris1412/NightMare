using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnFlashLight : MonoBehaviour
{
    public GameObject flashLight;
    public Transform flPos;
    int count = 0;
    private void Start()
    {
        switch(count)
        {
            case 0:
                {
                    SpawnFLight();
                    count++;
                    break;
                }
            default: break;
        }
    }
    public void SpawnFLight()
    {
        if (flashLight)
        {
            Instantiate(flashLight, flPos.position, Quaternion.identity);
        }
    }
}
