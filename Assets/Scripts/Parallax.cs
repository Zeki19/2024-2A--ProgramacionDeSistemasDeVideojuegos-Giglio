using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private Material mat;
    [Range(0f, 0.5f)] public float speed = 0.2f;
    private Vector2 _currentOffset;
    private static readonly int MainTex = Shader.PropertyToID("_MainTex");

    private void Start()
    {
        mat = GetComponent<Renderer>().material;
        _currentOffset = Vector2.zero;
    }
    
    public void Move(float deltaMovement)
    {
        _currentOffset.x += deltaMovement * speed;
        mat.SetTextureOffset(MainTex, _currentOffset);
    }
}
