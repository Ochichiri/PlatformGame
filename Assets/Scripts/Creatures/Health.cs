using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;

    public int MaxHealth => _maxHealth;
    public int CurrentHealth { get; private set; }

    public event Action<int, int> HealthChanged;

    private void Awake()
    {
        CurrentHealth = _maxHealth;
    }

    public void Start()
    {
        HealthChanged?.Invoke(CurrentHealth, _maxHealth);
    }

    public void GetDamage(int damage)
    {
        if (damage > 0)
        {
            CurrentHealth -= damage;
        }

        HealthChanged?.Invoke(CurrentHealth, _maxHealth);
    }

    public void Heal(int heal)
    {
        if (heal > 0)
        {
            CurrentHealth += heal;
            if (CurrentHealth > _maxHealth)
            {
                CurrentHealth = MaxHealth;
            }
        }

        HealthChanged?.Invoke(CurrentHealth, _maxHealth);
    }
}