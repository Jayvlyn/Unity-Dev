using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] GameObject pickupPrefab = null;

    private void OnCollisionEnter(Collision collision)
    {
        //print(collision.gameObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            player.AddPoints(4000);
        }

        Destroy(gameObject);
        Instantiate(pickupPrefab, transform.position, Quaternion.identity);
    }
}
