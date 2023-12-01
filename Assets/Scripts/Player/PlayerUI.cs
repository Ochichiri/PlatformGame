using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _gemCounterText;

    public void AddGem(int count)
    {
        _gemCounterText.text = count.ToString();
    }
}