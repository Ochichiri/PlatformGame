using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CreatureCollider))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(ColorChanger))]
[RequireComponent(typeof(SpriteRenderer))]
public class Creature : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private int _punchStrength;

    private ColorChanger _colorChanger;
    private Health _health;

    private void Awake()
    {
        _colorChanger = GetComponent<ColorChanger>();
        _health = GetComponent<Health>();
    }

    public void GetDamage(int damage, Vector3 collisionPosition, int punchStrength)
    {
        _health.GetDamage(damage);

        if (gameObject.TryGetComponent(out Rigidbody2D rigidbody))
        {
            rigidbody.velocity = Vector2.zero;
            rigidbody.AddForce((transform.position - collisionPosition) * punchStrength, ForceMode2D.Force);
        }

        _colorChanger.ChangeColor(Color.red);
    }

    public void Attack(Creature creature)
    {
        creature.GetDamage(_damage, transform.position, _punchStrength);
    }
}