using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Paper : MonoBehaviour
{
    SpriteRenderer sr;
    public Sprite active, passive;
    public bool canTake = false;
    MapManager m_map;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        m_map = FindObjectOfType<MapManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            sr.sprite = active;
            m_map.isTookMap = true;
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            sr.sprite = passive;
            canTake = false;
        }
    }

}
