using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taxi : MonoBehaviour
{
    private float speed = 8f;
    Rigidbody2D m_rb;
    
    private float timeToRun = 3f;
    public bool m_stoping = false;
    GameController m_gc;
    Player m_pl;

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_gc = FindObjectOfType<GameController>();
        m_pl = FindObjectOfType<Player>();
        TaxiRun();
        Destroy(gameObject, 6f);
    }

    // Update is called once per frame
    void Update()
    {
        if(m_stoping == true)
        {
            timeToRun -= Time.deltaTime;
            if(timeToRun <= 2f && timeToRun >= 1.997f)
            {
                //m_pl.SetPosition();
            }
            if(timeToRun <= 1f)
            {
                TaxiRun();
            }
        }
    }
    public void TaxiRun()
    {
        m_rb.velocity = Vector2.right * speed;
    }
    public void TaxiStop()
    {
        m_rb.velocity = Vector2.zero;
        m_stoping = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("StopPoint"))
        {
            TaxiStop();
        }
    }

}
