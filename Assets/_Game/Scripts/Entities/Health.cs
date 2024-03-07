using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    private float _minHealth = 0;

    public float currentHealth;

    private void Awake()
    {
        currentHealth = _maxHealth;
    }

    public void GainHealth(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > _maxHealth)
        {
            currentHealth = _maxHealth;
        }
    }

    public float TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, _minHealth, _maxHealth); //makes sure health doesnt go past the max and min
        if(currentHealth <= 0)
        {
            Die();
        }
        return currentHealth;
    }

    public void Die()
    {
        
    }
}
