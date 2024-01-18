using UnityEngine;

public class TimePickup : MonoBehaviour
{
    [SerializeField] GameObject pickupPrefab = null;
    [SerializeField] int time = 5;
    [SerializeField] AudioClip clip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            player.AddTime(time);
        }

        SoundManager.Instance.PlaySound(clip);
        Destroy(gameObject);
        Instantiate(pickupPrefab, transform.position, Quaternion.identity);
    }
}
