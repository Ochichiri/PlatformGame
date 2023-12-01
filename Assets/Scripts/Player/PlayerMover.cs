using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private PlayerGroundCheck _groundConnection;

    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Move(float strength)
    {
        float speed = strength * _speed;
        _rigidbody2D.velocity = new Vector2(speed, _rigidbody2D.velocity.y);
    }

    public void TryFlip(float speed)
    {
        if (speed < 0)
        {
            _spriteRenderer.flipX = true;
        }
        else
        {
            _spriteRenderer.flipX = false;
        }
    }

    public void Jump()
    {
        if (_groundConnection.IsOnGround)
        {
            Vector2 direction = Vector2.up * _jumpForce;
            _rigidbody2D.AddForce(direction, ForceMode2D.Impulse);
        }
    }
}