using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Units;
using UnityEngine.Serialization;

public class NpcHealth : MonoBehaviour, IHealth
{
    private NpcManager _npc;
    
    [SerializeField] private HealthBar healthBar;
    [SerializeField] public GameObject canvasHealthBar;
    
    [SerializeField] private int currentHealth; 
    private bool _isDead;

    private ServiceLocator _serviceLocator;
    private IPoolService _poolService;
    
    private void Awake()
    {
        _npc = GetComponent<NpcManager>();
        _serviceLocator = ServiceLocator.Instance;
        _poolService = _serviceLocator.GetService<IPoolService>();
    }
    private void OnEnable()
    {
        ResetHealth();
    }

    public int GetCurrentHealth() => currentHealth;
    public int GetMaxHealth() => _npc.MaxHealth;

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.ShowHealthBar();

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
            currentHealth = Mathf.Min(currentHealth + healingAmount, _npc.MaxHealth);
        }
    }
    public void Die()
    {
        _isDead = true;
        _poolService?.ReturnToPool(gameObject);
        healthBar.HideHealthBar();
    }

    public bool IsAlive()
    {
        return !_isDead;
    }

    public void ResetHealth()
    {
        currentHealth = _npc.MaxHealth;
        SetUpHealthBar();
    }

    private void SetUpHealthBar()
    {
        healthBar.HideHealthBar();
        canvasHealthBar = GameObject.FindWithTag("HealthBars");
        healthBar.transform.SetParent(canvasHealthBar.transform);
        healthBar.SetMaxHealth(GetMaxHealth());  
    }
}
