using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Units;
using UnityEditor.Experimental.GraphView;

public class ClassStates : MonoBehaviour
{
    private enum State
    {
        Searching,
        Attacking,
        Cooldown
    }
    
    // Scripts and Components
    public UnitInfo unitInfo;
    private UnitMovement _unitMovement;
    private SpriteRenderer _spriteRenderer;
    
    //Detection info
    private const int EnemyLayer = 6;
    private const int AllyLayer = 7;
    private UnitClass _unitClass;

    // State and Combat variables
    [SerializeField] State currentState;
    private bool _canAttack;
    private RaycastHit2D _target;
    private IHealth _targetHealth;
    private Vector2 _rangeDir;
    private int _checkingLayer;
    private bool _isOnCooldown;
    
    public void InitializeUnit(UnitInfo theUnitInfo)
    {
        unitInfo = theUnitInfo;
        _unitClass = unitInfo.unitClass;
        _unitMovement = GetComponent<UnitMovement>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _checkingLayer = _unitMovement.enemy ? AllyLayer : EnemyLayer;
        _rangeDir = _unitMovement.enemy ? Vector2.left : Vector2.right;
        _canAttack = true;
        _isOnCooldown = false;
        ResetTarget();
        UpdateVisuals();
    }
    public void BeginUnit()
    {
        TransitionToState(State.Searching);
    }
    private void Update()
    {
        switch (currentState)
        {
            case State.Searching:
                HandleSearchingState();
                break;
            case State.Attacking:
                HandleAttackingState();
                break;
            case State.Cooldown:
                HandleCooldownState();
                break;
        }
    }
    private void HandleSearchingState()
    {
        _target = Physics2D.Raycast(transform.position, _rangeDir, unitInfo.detectionRange, 1 << _checkingLayer);
        if (_target.collider is not null)
        {
            _targetHealth = _target.collider.GetComponent<IHealth>();
            if (_targetHealth.IsAlive())
            {
                TransitionToState(State.Attacking);
            }
            else
            {
                ResetTarget();
            }
            
        }
    }
    private void HandleAttackingState()
    {
        if (_targetHealth == null || !_targetHealth.IsAlive() || IsTargetOutOfRange())
        {
            ResetTarget();
            TransitionToState(State.Searching);
            return;
        }

        if (!_canAttack || _isOnCooldown) return;
        ExecuteAttack();
        TransitionToState(State.Cooldown);
    }
    private bool IsTargetOutOfRange()
    {
        if (_target.collider is null) return true;
        float distanceToTarget = Vector2.Distance(transform.position, _target.collider.transform.position);
        return distanceToTarget > unitInfo.detectionRange;
    }
    private void ExecuteAttack()
    {
        _unitMovement.StopMovement();
        
        switch (_unitClass)
        {
            case UnitClass.Melee:
                MeleeAttack();
                break;
            case UnitClass.Ranged:
                RangedAttack();
                break;
        }
    }
    private void MeleeAttack()
    {
        _targetHealth?.TakeDamage(unitInfo.damage);
        _canAttack = false;
    }
    private void RangedAttack()
    {
        if (_target.collider is not null)
        {
            ArrowManager.Instance.ShootArrow(transform, _target.collider, unitInfo.damage);
            _canAttack = false;
        }
    }
    private void HandleCooldownState()
    {
        if(_isOnCooldown)return;
        StartCoroutine(CooldownRoutine());
    
        if (_targetHealth == null || !_targetHealth.IsAlive() ||IsTargetOutOfRange())
        {
            TransitionToState(State.Searching);
        }
        else
        {
            TransitionToState(State.Attacking);
        }
    }
    private IEnumerator CooldownRoutine()
    {
        _isOnCooldown = true;
        yield return new WaitForSeconds(unitInfo.attackCooldown);
        _isOnCooldown = false;
        _canAttack = true;
        TransitionToState(State.Attacking);
    }
    private void TransitionToState(State newState)
    { 
        currentState = newState;
        switch (newState)
        {
            case State.Searching:
                _unitMovement.StartMovement();
                break;
            case State.Attacking:
            case State.Cooldown:
                break;
        }
    }
    private void UpdateVisuals()
    {
        _spriteRenderer.sprite = unitInfo.classSprite;
    }
    private void ResetTarget()
    {
        _target = default;
        _targetHealth = null;
    }
    
}
