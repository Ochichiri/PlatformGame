using UnityEngine;

[RequireComponent(typeof(PlayerUI))]
public class Player : MonoBehaviour
{
    private int _gemCounter;
    private PlayerUI _playerUI;

    private void Start()
    {
        _gemCounter = 0;
        _playerUI = GetComponent<PlayerUI>();
    }

    public void AddGem()
    {
        _gemCounter++;
        _playerUI.AddGem(_gemCounter);
    }
}