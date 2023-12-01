using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private List<Transform> _points;

    private SpriteRenderer _spriteRenderer;
    private int _currentPoint = 0;
    private int _speed = 1;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        Flip(_points[_currentPoint]);
    }

    private void FixedUpdate()
    {
        Vector3 targetPosition = new Vector3(_points[_currentPoint].position.x, transform.position.y);

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.fixedDeltaTime);

        if (transform.position.x == targetPosition.x)
        {
            _currentPoint++;

            if (_currentPoint == _points.Count)
            {
                _currentPoint = 0;
            }

            Flip(_points[_currentPoint]);
        }
    }

    public void Flip(Transform target)
    {
        float horizontalDirection = target.position.x - transform.position.x;
        if (horizontalDirection < 0)
        {
            _spriteRenderer.flipX = true;
        }
        else
        {
            _spriteRenderer.flipX = false;
        }
    }
}