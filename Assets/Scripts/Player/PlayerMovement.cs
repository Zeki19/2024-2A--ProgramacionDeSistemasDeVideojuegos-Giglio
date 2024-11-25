using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UIElements;


public class PlayerMovement : MonoBehaviour
{
    // Movement Variables
    public float speed = 5f;
    private Rigidbody2D rb;
    private float moveInput;
    
    // Ability Variables (Strategy Pattern)
    public AbilityManager abilityManager;
    
    private void Start()
    {
        rb = GetComponent <Rigidbody2D>();
    }

    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        Move();
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            AbilityManager.Instance.UseAbility(transform, Vector2.right, LayerMask.NameToLayer("Enemy"));
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (RangedCheck())
            {
                Shoot();
            }
        }
    }

    private RaycastHit2D _hit;
    private bool RangedCheck()
    {
        _hit = Physics2D.Raycast(transform.position, Vector2.right, 6, 1 << 6);
        return _hit.collider != null;
    }
    private void Shoot()
    {
        ArrowManager.Instance.ShootArrow(transform, _hit.collider, 10);
    }
    
    private void Move()
    {
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }
    

}
