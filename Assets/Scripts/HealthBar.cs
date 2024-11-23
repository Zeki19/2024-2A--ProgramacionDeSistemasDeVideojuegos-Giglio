using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider _slider;
    [SerializeField] private Transform Target;
    [SerializeField] private Vector3 Offset;
    
    private void Update()
    {
        transform.position = Target.position + Offset;
    }
    public void SetMaxHealth(int health)
    {
        _slider.maxValue = health;
        _slider.value = health;
    }

    public void SetHealth(int health)
    {
        _slider.value = health;
    }

    public void ShowHealthBar()
    {
        gameObject.SetActive(true);
    }

    public void HideHealthBar()
    {
        gameObject.SetActive(false);
    }
}
