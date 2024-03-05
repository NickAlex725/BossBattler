using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    private int _minHealth = 0;

    public int currentHealth;

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

    public int TakeDamage(int damageAmount)
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
