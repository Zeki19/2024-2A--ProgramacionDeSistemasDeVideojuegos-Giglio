using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class NpcMovement : MonoBehaviour
    {
        private NpcManager _npcManager;
        
        private Vector2 _direction;
        private Rigidbody2D rb;

        private int _layerToExclude;
        
        private int AllyLayer = 1 << 7;
        private int EnemyLayer = 1 << 6;
        

        private void Awake()
        {
            _npcManager = GetComponent<NpcManager>();
            rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            rb.velocity = _npcManager.CanMove ? _direction * _npcManager.MovementSpeed : Vector2.zero;
        }
        
        public void ResetMovement()
        {
            if (_npcManager.IsEnemy)
            {
                _direction = Vector2.left;
                rb.excludeLayers = EnemyLayer;
            }
            else
            {
                _direction = Vector2.right;
                rb.excludeLayers = AllyLayer;
            }
        }
    }

