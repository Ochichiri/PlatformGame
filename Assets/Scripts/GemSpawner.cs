using System.Collections;
using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    [SerializeField] private Gem _gemTemplate;

    private Gem _currentGem;
    private int _capacity = 3;
    private WaitForSeconds _waitDelay;
    private float _delay = 5f;

    private void Start()
    {
        _waitDelay = new WaitForSeconds(_delay);

        StartCoroutine(Spawn()); 
    }

    private IEnumerator Spawn()
    {
        for (int i = 0; i < _capacity;)
        {
            if (_currentGem == null)
            {
                _currentGem = Instantiate(_gemTemplate, transform.position, Quaternion.identity);
                i++;
            }

            yield return _waitDelay;
        }
    }
}