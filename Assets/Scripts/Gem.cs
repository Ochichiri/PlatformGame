using UnityEngine;

public class Gem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.AddGem();
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}