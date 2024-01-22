using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMover _playerMover;
    private Player _player;

    private void Start()
    {
        _playerMover = GetComponent<PlayerMover>();
        _player = GetComponent<Player>();
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

        if (Input.GetKeyDown(KeyCode.E))
        {
            _player.Lifesteal();
        }
    }
}