using System;
using System.Collections;
using System.Collections.Generic;
using Units;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.Serialization;

public class NpcManager : MonoBehaviour
{
    [SerializeField] private UnitInfo unitInfo;

    private const int AllyLayer = 1 << 7;
    private const int EnemyLayer = 1 << 6;

    private SpriteRenderer _sprite;

    private IState _currentState;
    private IAttackStrategy attackStrategy;
    
    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }
    private void OnEnable()
    {
        
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
    //bool IsEnemy { get; set; }
    public bool CanMove { get; set; }
    public bool CanAttack { get; set; }

    [SerializeField] public bool IsEnemy;

    [HideInInspector] public Collider2D target;

    public void Initialize(UnitClass unitClass, bool enemyStatus)
    {
        IsEnemy = enemyStatus;
        
        UnitInfo newUnitInfo = UnitInfoFactory.GetUnitInfo(unitClass.ToString()); //Should use AbstractFactory
        unitInfo = newUnitInfo;
        
        _sprite.sprite = unitInfo.classSprite;
        _sprite.color = IsEnemy ? Color.red : Color.blue;
        gameObject.layer = IsEnemy ? 6 : 7;
        CanAttack = true;
        
        gameObject.GetComponent<NpcMovement>().ResetMovement();
        AttackStrat();
        ChangeState(new MarchingState());
    }
    
    //Utility
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
