using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnObjectsToPersist : MonoBehaviour
{
    [SerializeField] GameObject ObjectToPersistPrefabs;
    
    private void Awake()
    {
        var existingObject = FindObjectsOfType<GameController>();
        if(existingObject.Length == 0 )
        {
            Instantiate(ObjectToPersistPrefabs, new Vector3(0, 0, 0), Quaternion.identity);
            
        }
    }
}
