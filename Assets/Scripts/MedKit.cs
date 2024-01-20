using UnityEngine;

public class MedKit : MonoBehaviour
{
    [SerializeField] private int _heal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.Heal(_heal);
            Destroy(gameObject);
        }
    }
}