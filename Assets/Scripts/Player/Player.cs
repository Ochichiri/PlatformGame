using System.Collections;
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

    public void Lifesteal()
    {
        Vector2 size = new Vector2(5f, 5f);
        RaycastHit2D[] hits = Physics2D.CapsuleCastAll(transform.position, size, CapsuleDirection2D.Horizontal, 0, Vector2.up);

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.TryGetComponent(out Enemy enemy))
            {
                StartCoroutine(HealthTransaction(enemy));
                return;
            }
        }
    }

    private IEnumerator HealthTransaction(Enemy enemy)
    {
        float currentTimeOfTransaction = 0f;
        float fullTimeOfTransaction = 6f;
        float delayBetweenTransaction = 0.1f;
        int healthDifference = 1;

        WaitForSeconds delay = new WaitForSeconds(delayBetweenTransaction);

        Health playerHealth = gameObject.GetComponent<Health>();
        Health enemyHealth = enemy.GetComponent<Health>();

        while (currentTimeOfTransaction < fullTimeOfTransaction)
        {
            if (enemy != null)
            {
                enemyHealth.GetDamage(healthDifference);
                playerHealth.Heal(healthDifference);
            }
            else
            {
                StopCoroutine(HealthTransaction(enemy));
            }

            currentTimeOfTransaction += delayBetweenTransaction;
            yield return delay;
        }
    }
}