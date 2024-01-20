using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private List<Transform> _points;
    [SerializeField] private LayerMask _layerMask;

    private SpriteRenderer _spriteRenderer;
    private int _currentPoint = 0;
    private int _speed = 1;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (TryFindPlayer(out Vector3 player))
        {
            MoveToPlyer(player);
        }
        else
        {
            MoveToPoints(); 
        }
    }

    private void MoveToPoints()
    {
        Vector3 targetPosition;

        targetPosition = new Vector3(_points[_currentPoint].position.x, transform.position.y);

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.fixedDeltaTime);

        if (transform.position.x == targetPosition.x)
        {
            _currentPoint++;

            if (_currentPoint == _points.Count)
            {
                _currentPoint = 0;
            }
        }

        Flip(_points[_currentPoint].position);
    }

    private void MoveToPlyer(Vector3 playerPosition)
    {
        Vector3 target = new Vector3(playerPosition.x, transform.position.y);
        transform.position = Vector3.MoveTowards(transform.position, target, _speed * Time.fixedDeltaTime);
        Flip(playerPosition);
    }

    public void Flip(Vector3 target)
    {
        float horizontalDirection = target.x - transform.position.x;
        if (horizontalDirection < 0)
        {
            _spriteRenderer.flipX = true;
        }
        else
        {
            _spriteRenderer.flipX = false;
        }
    }

    private bool TryFindPlayer(out Vector3 playerPosition)
    {
        float rayDistance = 20f;
        Vector3 originOfRay = new Vector3(transform.position.x - rayDistance/2, transform.position.y, transform.position.z);

        RaycastHit2D hit = Physics2D.Raycast(originOfRay, transform.TransformDirection(Vector3.left), rayDistance, _layerMask);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.TryGetComponent(out Player player))
            {
                playerPosition = hit.collider.transform.position;
                return true;
            }
        }

        playerPosition = Vector3.zero;
        return false;
    }
}