using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] public Image healthBar;
    [SerializeField] public TextMeshProUGUI valueText;
    [SerializeField] private float currentHealth;
    [SerializeField] private float maxHealth;

    public void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        healthBar.fillAmount = currentHealth / maxHealth;
        valueText.text = currentHealth.ToString() + " / " + maxHealth.ToString();
    }

}
