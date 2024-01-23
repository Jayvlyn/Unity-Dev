using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePickup : Pickup
{
    [SerializeField] int damage = 50;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player) && !pickedUp)
        {
            player.TakeDamage(damage);
        }
        base.OnTriggerEnter(other);
    }
}
