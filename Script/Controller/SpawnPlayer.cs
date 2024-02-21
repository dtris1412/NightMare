using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    Player m_pl;
    GameController m_gc;
    public GameObject player;
    public float posX;
    public float posY;
    private string priviousScenesName;
    public Transform Player;
    void Start()
    {
        m_pl  =  FindObjectOfType<Player>();
        m_gc = FindObjectOfType<GameController>();
        Vector2 newPosiotion = new Vector2(posX, posY);
        
        priviousScenesName = SceneManager.GetActiveScene().name;
    }
    private void Update()
    {
        
    }

    // Update is called once per frame

}
