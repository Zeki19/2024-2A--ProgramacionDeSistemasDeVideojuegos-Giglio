using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Slider _slider;
    [SerializeField] public GameObject canvasHealthBar;
    private void Start()
    {
        _slider = GetComponent<Slider>();
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
