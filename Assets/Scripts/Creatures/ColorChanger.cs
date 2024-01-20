using System.Collections;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private float _colorDelayTime = 0.1f;
    private float _colorChangeTime = 1f;
    private WaitForSeconds _colorChangeDelay;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _colorChangeDelay = new WaitForSeconds(_colorDelayTime);
    }

    public void ChangeColor(Color color)
    {
        StartCoroutine(Change(color));
    }

    private IEnumerator Change(Color color)
    {
        float halfColorValue = 0.3f;
        float currentTime = halfColorValue;
        float maxColorValue = 1f;

        while (currentTime < _colorChangeTime)
        {
            float green = Mathf.Clamp(currentTime, halfColorValue, maxColorValue);
            float blue = Mathf.Clamp(currentTime, halfColorValue, maxColorValue);
            _spriteRenderer.color = new Color(1f, green, blue);

            currentTime += _colorDelayTime;
            yield return _colorChangeDelay;
        }

        _spriteRenderer.color = Color.white;
    }
}
