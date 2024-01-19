using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CreatureCollider))]
[RequireComponent(typeof(ColorChanger))]
[RequireComponent(typeof(SpriteRenderer))]
public class Creature : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _damage;
    [SerializeField] private int _punchStrength;

    private int _currentHealth;
    private ColorChanger _colorChanger;

    private void Awake()
    {
        _currentHealth = _maxHealth;
        _colorChanger = GetComponent<ColorChanger>();
    }

    public void GetDamage(int damage, Vector3 collisionPosition)
    {
        if (damage > 0)
        {
            _currentHealth -= damage;
        }

        if (gameObject.TryGetComponent(out Rigidbody2D rigidbody))
        {
            rigidbody.velocity = Vector2.zero;
            rigidbody.AddForce((transform.position - collisionPosition) * _punchStrength, ForceMode2D.Force);
        }

        _colorChanger.ChangeColor(Color.red);
    }

    public void Attack(Creature creature)
    {
        creature.GetDamage(_damage, transform.position);
    }
}