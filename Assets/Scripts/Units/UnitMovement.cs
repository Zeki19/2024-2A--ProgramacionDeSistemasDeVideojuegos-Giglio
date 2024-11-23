using System;
using UnityEngine;
using Units;
using UnityEditor;

public class UnitMovement : MonoBehaviour
    {
        private UnitInfo unitInfo;
        float _actualSpeed;
        public bool enemy;
        private Vector2 direction;
        private Rigidbody2D rb;
        private SpriteRenderer spriteRenderer;
        private const int EnemyLayer = 6;
        private const int AllyLayer = 7;

        private bool isMoving;
        public void InitializeUnit(UnitInfo theUnitInfo, bool isEnemy)
        {
            unitInfo = theUnitInfo;
            _actualSpeed = theUnitInfo.movementSpeed;
            enemy = isEnemy;
            gameObject.layer = enemy ? EnemyLayer : AllyLayer;
            direction = enemy ? Vector2.left : Vector2.right;
            spriteRenderer = GetComponent<SpriteRenderer>();
            rb = GetComponent<Rigidbody2D>();
            
            UpdateVisuals();
            StartMovement();
        }

        private void UpdateVisuals()
        {
            spriteRenderer.color = enemy ? Color.red : Color.blue;
        }

        private void FixedUpdate()
        {
            if (isMoving)
            {
                Move();
            }
        }

        private void Move()
        {
            rb.velocity = direction * _actualSpeed;
        }

        public void StartMovement()
        {
            isMoving = true;
            _actualSpeed = unitInfo.movementSpeed;
            rb.velocity = direction * _actualSpeed;
            UpdateLayerCollision();
        }
        
        private void UpdateLayerCollision()
        {
            if (enemy)
            {
                rb.excludeLayers = 1 << EnemyLayer;
            }
            else
            {
                rb.excludeLayers = 1 << AllyLayer;
            }
        }

        public void StopMovement()
        {
            isMoving = false;
            rb.velocity = Vector2.zero;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            isMoving = false;
            rb.velocity = Vector2.zero;
        }
    }
