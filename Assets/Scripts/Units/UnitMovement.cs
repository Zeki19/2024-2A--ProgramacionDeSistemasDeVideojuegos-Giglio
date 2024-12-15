using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class UnitMovement : MonoBehaviour
    {
        private Unit _unit;
        private Vector2 _direction;
        private Rigidbody2D _rb;

        private int _layerToExclude;
        
        private readonly int _allyLayer = 1 << 7;
        private readonly int _enemyLayer = 1 << 6;
        
        private void Awake()
        {
            _unit = GetComponent<Unit>();
            _rb = GetComponent<Rigidbody2D>();
            _unit.OnFactionChanged += ResetMovement;
            ResetMovement();
        }
        private void FixedUpdate()
        {
            _rb.velocity = _unit.CanMove ? _direction * _unit.MovementSpeed : Vector2.zero;
        }
        private void ResetMovement()
        {
            if (_unit.IsEnemy)
            {
                _direction = Vector2.left;
                _rb.excludeLayers = _enemyLayer;
            }
            else
            {
                _direction = Vector2.right;
                _rb.excludeLayers = _allyLayer;
            }
        }
        private void OnDestroy()
        {
            _unit.OnFactionChanged -= ResetMovement;
        }
    }

