using System;
using System.Collections;
using System.Collections.Generic;
using Units;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.Serialization;

public class Unit : MonoBehaviour
{
    [SerializeField] private UnitInfo unitInfo;

    public event Action OnFactionChanged;
    
    private const int AllyLayer = 1 << 7;
    private const int EnemyLayer = 1 << 6;

    private SpriteRenderer _sprite;

    private IState _currentState;
    private IAttackStrategy attackStrategy;
    
    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        _currentState?.UpdateState(this);
    }
    public void ChangeState(IState newState)
    {
        _currentState?.ExitState(this);
        _currentState = newState;
        _currentState.EnterState(this);
    }
    
    public int MaxHealth => unitInfo.maxHealth;
    public float MovementSpeed => unitInfo.movementSpeed;
    public int Damage => unitInfo.damage;
    public float Cooldown => unitInfo.attackCooldown;
    public float Range => unitInfo.range;
    public int TargetLayer => IsEnemy ? AllyLayer : EnemyLayer;
    public bool CanMove { get; set; }
    public bool CanAttack { get; set; }

    private bool _isEnemy;
    public bool IsEnemy
    {
        get => _isEnemy;
        private set
        {
            if (_isEnemy != value)
            {
                _isEnemy = value;
                OnFactionChanged?.Invoke();
            }
        }
    }

    [HideInInspector] public Collider2D target;

    public void Initialize(UnitClass unitClass, bool enemyStatus)
    {
        IsEnemy = enemyStatus;
        
        UnitInfo newUnitInfo = UnitInfoFactory.GetUnitInfo(unitClass.ToString());
        unitInfo = newUnitInfo;
        UpdateSprite();
        gameObject.layer = _isEnemy ? 6 : 7;
        CanAttack = true;
        
        AttackStrat();
        ChangeState(new MarchingState());
    }
    

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
    public bool IsTargetValid()
    {
        if (target == null) return false;

        IHealth targetHealth = target.GetComponent<IHealth>();
        if (targetHealth == null || !targetHealth.IsAlive()) return false;

        float distanceToTarget = Vector2.Distance(transform.position, target.transform.position);
        
        return distanceToTarget <= Range;
    }
    private void UpdateSprite()
    {
        _sprite.sprite = unitInfo.classSprite;
        if (_isEnemy)
        {
            _sprite.color = Color.red;
            _sprite.flipX = true;
        }
        else
        {
            _sprite.color = Color.blue;
            _sprite.flipX = false;
        }
    }
    private void AttackStrat()
    {
        if (unitInfo.unitClass == UnitClass.Ranged)
        {
            attackStrategy = new RangedAttackStrategy();
        }
        else if (unitInfo.unitClass == UnitClass.Melee)
        {
            attackStrategy = new MeleeAttackStrategy();
        }
    }
    public void PerformAttack()
    {
        attackStrategy?.Attack(this, target);
    }
}
