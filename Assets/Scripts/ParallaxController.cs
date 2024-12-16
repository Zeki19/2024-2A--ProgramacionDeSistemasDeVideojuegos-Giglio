using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    public Parallax[] backgrounds;
    public Transform camTransform;
    private Vector3 _previousPosition;

    private void Start()
    {
        _previousPosition = camTransform.position;
    }

    private void FixedUpdate()
    {
        float deltaMovement = camTransform.position.x - _previousPosition.x;
        
        foreach (var parallax in backgrounds)
        {
            if (parallax)
            {
                parallax.Move(deltaMovement);
            }
        }
        
        _previousPosition = camTransform.position;
    }
}
