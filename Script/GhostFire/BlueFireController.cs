using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class BlueFireController : MonoBehaviour
{
    public GameObject blueFire;
    bool isSpawn;
    float timeToSpawn = 3f;
    float m_timeToSpawn;
    float timeToDestroy;
    // Start is called before the first frame update
    void Start()
    {
        m_timeToSpawn = timeToSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        
        m_timeToSpawn -= Time.deltaTime;
        if (m_timeToSpawn <= 0)
        {
            SpawnBlueFire();
            
            m_timeToSpawn = timeToSpawn;
        }
    }

    public void SpawnBlueFire()
    {
        
        if(blueFire)
        {
            for(int i = 0; i < 10; i++)
            {
                Vector2 spawnPos = new Vector2(Random.Range(-12, 12), Random.Range(-4, 5));
               
                GameObject spawniedFire = Instantiate(blueFire, spawnPos, Quaternion.identity);
                Destroy(spawniedFire, 2.5f);
            } 
        }
    }
}
