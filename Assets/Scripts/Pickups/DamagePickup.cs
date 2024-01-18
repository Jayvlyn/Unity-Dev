using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePickup : MonoBehaviour
{
    [SerializeField] GameObject pickupPrefab = null;
    [SerializeField] int damage = 50;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            player.TakeDamage(damage);
        }

        Destroy(gameObject);
        Instantiate(pickupPrefab, transform.position, Quaternion.identity);
    }
}
