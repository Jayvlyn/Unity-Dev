using UnityEngine;

public class TimePickup : MonoBehaviour
{
    [SerializeField] GameObject pickupPrefab = null;
    [SerializeField] int time = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            player.AddTime(time);
        }

        Destroy(gameObject);
        Instantiate(pickupPrefab, transform.position, Quaternion.identity);
    }
}
