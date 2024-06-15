using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BodyPartManager : MonoBehaviour
{
    public GameObject head;
    public GameObject rightArm;
    public GameObject leftArm;
    public GameObject rightLeg;
    public GameObject leftLeg;
    public GameObject body;

    public Transform hPos;
    public Transform raPos;
    public Transform laPos;
    public Transform rlPos;
    public Transform llPos;
    public Transform bPos;

    private static int spawnCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
        switch(spawnCount)
        {
            case 1:
                {
                    SpawnHeadPart();
                    
                    break;
                }
            case 2:
                {
                    SpawnBodyPart();
                    
                    break;
                }
            case 3:
                {
                    SpawnRightArmPart();
                    
                    break;
                }
            case 4:
                {
                    SpawnLeftArmPart();
                    
                    break;
                }
            case 5:
                {
                    SpawnRightLegPart();
                    
                    break;
                }
            case 6:
                {
                    SpawnLeftLegPart();
                  
                    break;
                }
            default:
                break;
        }
        spawnCount++;
    }
    public void SpawnHeadPart()
    {
        if(head)
        {
            Instantiate(head, hPos.position, Quaternion.identity);
        }
    }
    public void SpawnRightArmPart()
    {
        if (rightArm)
        {
            Instantiate(rightArm, raPos.position, Quaternion.identity);
        }
    }
    public void SpawnLeftArmPart()
    {
        if (leftArm)
        {
            Instantiate(leftArm, laPos.position, Quaternion.identity);
        }
    }
    public void SpawnRightLegPart()
    {
        if (rightLeg)
        {
            Instantiate(rightLeg, rlPos.position, Quaternion.identity);
        }
    }
    public void SpawnLeftLegPart()
    {
        if (leftLeg)
        {
            Instantiate(leftLeg, llPos.position, Quaternion.identity);
        }
    }
    public void SpawnBodyPart()
    {
        if (body)
        {
            Instantiate(body, bPos.position, Quaternion.identity);
        }
    }
    
}
