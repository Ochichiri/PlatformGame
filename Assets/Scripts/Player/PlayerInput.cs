using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(Animator))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMover _playerMover;
    private Animator _animator;
    
    private void Start()
    {
        _playerMover = GetComponent<PlayerMover>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.W))
        {
            _playerMover.Jump();
        }

        if (horizontal != 0)
        {
            _playerMover.Move(horizontal);
            _playerMover.TryFlip(horizontal);
        }

        _animator.SetFloat("Speed", Mathf.Abs(horizontal));
    }
}