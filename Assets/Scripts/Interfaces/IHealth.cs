using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth
{
    bool IsAlive();
    int GetCurrentHealth();
    int GetMaxHealth();
    void TakeDamage(int damage);
    void Heal(int healingAmount);
    void Die();
    void ResetHealth();
}
