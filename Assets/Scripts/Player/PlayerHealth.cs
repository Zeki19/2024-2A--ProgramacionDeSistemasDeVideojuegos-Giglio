using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHealth
{
    [SerializeField] private PlayerHealthBar _healthBar;
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;
    private bool isDead;
    private void Start()
    {
        currentHealth = maxHealth;
        isDead = false;
        _healthBar.SetMaxHealth(maxHealth);
    }

    public int GetCurrentHealth() => currentHealth;
    public int GetMaxHealth() => maxHealth;

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        _healthBar.SetHealth(currentHealth);
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void Heal(int healingAmount)
    {
        if (!isDead)
        {
            currentHealth = Mathf.Min(currentHealth + healingAmount, maxHealth);
        }
    }
    public void Die()
    {
        isDead = true;
        Destroy(gameObject);
        
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    public bool IsAlive()
    {
        return !isDead;
    }
    public void ResetHealth()
    {
        throw new System.NotImplementedException();
    }
}
