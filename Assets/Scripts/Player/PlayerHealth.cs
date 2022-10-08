using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private Image healthBar;

    private float currentHealth;
    private Vector3 initialPosition;
    private Vector3 initialRotation;

    void Start()
    {
        currentHealth = maxHealth;
        initialPosition = transform.position;
        initialRotation = transform.eulerAngles;
        healthBar.fillAmount = 1f;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.fillAmount = currentHealth / maxHealth;

        if(currentHealth <= 0)
        {
            transform.position = initialPosition;
            transform.eulerAngles = initialRotation;

            Destroy(gameObject);
        }
    }
}
