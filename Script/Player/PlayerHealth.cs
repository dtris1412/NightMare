using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private static int currentHealth = 0;
    int maxHealth = 100;
    private static int life = 5;
    public bool islose = false;
    UIManager m_ui;
    
    private void Start()
    {
        m_ui = FindObjectOfType<UIManager>();
        m_ui.SetLifeText("x" + life);
        currentHealth = maxHealth;
    }
    private void Update()
    {
/*        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDame(50);
        }*/
    }
    public void TakeDame(int dame)
    {
        currentHealth -= dame;
        m_ui.UpdateBar(currentHealth, maxHealth);
        if(currentHealth <= 0)
        {
            ReloadHealth();
            LifeIncrement();
        }
    }
    public void LifeIncrement()
    {
        life--;
        m_ui.SetLifeText("X" + life);
        if (life <= 0)
        {
            life = 0;
            islose = true;
            Debug.Log("Ban da thua");
            m_ui.ShowGameLose();

        }
    }
    public void ReloadHealth()
    {
        currentHealth = maxHealth;
    }

}
