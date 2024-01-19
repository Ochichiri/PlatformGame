using UnityEngine;

[RequireComponent(typeof(Creature))]
public class CreatureCollider : MonoBehaviour
{
    private Creature _creature;

    private void Awake()
    {
        _creature = GetComponent<Creature>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Creature creature))
        {
            _creature.Attack(creature);
        }
    }
}