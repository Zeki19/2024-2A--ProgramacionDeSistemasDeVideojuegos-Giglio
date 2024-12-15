using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHealth
{
    [SerializeField] private PlayerHealthBar healthBar;
    [SerializeField] public int maxHealth;
    [SerializeField] private int currentHealth;
    private bool _isDead;
    private void Start()
    {
        currentHealth = maxHealth;
        _isDead = false;
        healthBar.SetMaxHealth(maxHealth);
    }

    public int GetCurrentHealth() => currentHealth;
    public int GetMaxHealth() => maxHealth;

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void Heal(int healingAmount)
    {
        if (!_isDead)
        {
            currentHealth = Mathf.Min(currentHealth + healingAmount, maxHealth);
        }
    }
    public void Die()
    {
        _isDead = true;
        Destroy(gameObject);
        
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    public bool IsAlive()
    {
        return !_isDead;
    }
    public void ResetHealth()
    {
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }
}
