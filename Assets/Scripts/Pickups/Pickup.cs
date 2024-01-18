using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] GameObject pickupPrefab = null;
    [SerializeField] int points = 4000;
    [SerializeField] AudioClip clip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            player.AddPoints(points);
        }

        SoundManager.Instance.PlaySound(clip);
        Destroy(gameObject);
        Instantiate(pickupPrefab, transform.position, Quaternion.identity);
    }
}
