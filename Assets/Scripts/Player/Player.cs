using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UIElements;


public class Player : MonoBehaviour
{
    // Movement Variables
    public float speed = 5f;
    private Rigidbody2D rb;
    private float moveInput;
    public int damage;
    private ServiceLocator service;
    
    
    private void Start()
    {
        rb = GetComponent <Rigidbody2D>();
        service = ServiceLocator.Instance;
    }

    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        Move();
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            service.GetService<IAbillityService>().UseAbility(transform, Vector2.right, LayerMask.NameToLayer("Enemy"));
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
        var arrow = service.GetService<IMediatorService>().GetArrow();
        arrow.ShootArrow(transform, _hit.collider, damage);
    }
    
    private void Move()
    {
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }
    

}
