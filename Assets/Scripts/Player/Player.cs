using UnityEngine;

[RequireComponent(typeof(PlayerUIChanger))]
public class Player : Creature
{
    private int _gemCounter;
    private PlayerUIChanger _playerUI;

    private void Start()
    {
        _gemCounter = 0;
        _playerUI = GetComponent<PlayerUIChanger>();
    }

    public void AddGem()
    {
        _gemCounter++;
        _playerUI.AddGem(_gemCounter);
    }
}