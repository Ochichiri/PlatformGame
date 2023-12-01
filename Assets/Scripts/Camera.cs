using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private Vector3 _offset;
    private float _speed = 0.125f;

    private void Start()
    {
        _offset = new Vector3(0, 1.5f, -10);
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, _player.position + _offset, _speed);
    }
}