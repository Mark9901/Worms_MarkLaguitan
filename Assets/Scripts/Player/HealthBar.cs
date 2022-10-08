using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public float maxHealth = 100;
    public float currentHealth;

    PlayerManager manager;

    private void Start()
    {
        currentHealth = maxHealth;
        SetMaxHealth(maxHealth);
        manager = GetComponent<PlayerManager>();
    }

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(float health)
    {
        slider.value = health;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        SetHealth(currentHealth);

        if(currentHealth <= 0)
        {
            Destroy(gameObject);
            manager.ShowWin();
        }
    }
}
