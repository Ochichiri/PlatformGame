using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]
public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _gemCounterText;
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private Slider _healthBar;

    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _health.HealthChanged += ResetHealthBar;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= ResetHealthBar;
    }

    public void AddGem(int count)
    {
        _gemCounterText.text = count.ToString();
    }

    public void ResetHealthBar(int health, int maxHealth)
    {
        _healthText.text = $"{health} / {maxHealth}";

        float percentOfHealth = (float)health / maxHealth;
        StartCoroutine(SliderChanger(percentOfHealth));
    }

    private IEnumerator SliderChanger(float percentOfHealth)
    {
        float currentValue = _healthBar.value;
        float targetValue = percentOfHealth;

        float changingStep = 0.01f;
        float changingDelay = 0.1f;
        WaitForSeconds delay = new WaitForSeconds(changingDelay);

        while (currentValue != targetValue)
        {
            currentValue = Mathf.MoveTowards(currentValue, targetValue, changingStep);
            _healthBar.value = currentValue;
            yield return delay;
        }
    }
}