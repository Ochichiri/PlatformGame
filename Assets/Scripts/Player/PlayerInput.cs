using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMover _playerMover;

    private void Start()
    {
        _playerMover = GetComponent<PlayerMover>();
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
    }
}