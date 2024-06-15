using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageDontDestroyonLoad : MonoBehaviour
{
    private Transform originalParent;

    void Start()
    {

        originalParent = transform.parent;
    }

    void Update()
    {

        if (transform.parent != originalParent && transform.parent != null)
        {
            // Đối tượng là con của Player
            if (transform.parent.CompareTag("Player"))
            {
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                RemoveDontDestroyOnLoad(gameObject);
            }
        }
    }

    void RemoveDontDestroyOnLoad(GameObject obj)
    {

        GameObject temp = new GameObject();
        obj.transform.parent = temp.transform;


        obj.transform.parent = null;


        Destroy(temp);
    }
}
