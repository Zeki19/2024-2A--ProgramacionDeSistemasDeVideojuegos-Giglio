using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Units;

public class UnitHealth : MonoBehaviour, IHealth
{
    private UnitInfo _unitInfo;
    
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private int currentHealth;
    [SerializeField] private bool _isDead;
    public GameObject canvasHealthBar;
    public void InitializeUnit(UnitInfo theUnitInfo)
    {
        _unitInfo = theUnitInfo;
        currentHealth = _unitInfo.maxHealth;
        _isDead = false;
        SetUpHealthBar();
    }

    public int GetCurrentHealth() => currentHealth;
    public int GetMaxHealth() => _unitInfo.maxHealth;

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        _healthBar.ShowHealthBar();

        _healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int healingAmount)
    {
        if (!_isDead)
        {
            currentHealth = Mathf.Min(currentHealth + healingAmount, _unitInfo.maxHealth);
        }
    }

    public void Die()
    {
        _isDead = true;
        UnitPool.Instance.ReturnUnit(gameObject);
        _healthBar.HideHealthBar();
    }

    public bool IsAlive()
    {
        return !_isDead;
    }

    public void ResetHealth()
    {
        
    }

    private void SetUpHealthBar()
    {
        _healthBar.HideHealthBar();
        canvasHealthBar = GameObject.FindWithTag("HealthBars");
        _healthBar.transform.SetParent(canvasHealthBar.transform);
        _healthBar.SetMaxHealth(_unitInfo.maxHealth);  
    }
}
