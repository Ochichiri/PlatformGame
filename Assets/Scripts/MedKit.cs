using UnityEngine;

public class MedKit : MonoBehaviour
{
    [SerializeField] private int _heal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() &&
            collision.TryGetComponent(out Health health))
        {
            health.Heal(_heal);
            Destroy(gameObject);
        }
    }
}