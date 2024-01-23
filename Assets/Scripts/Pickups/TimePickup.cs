using UnityEngine;

public class TimePickup : Pickup
{
    [SerializeField] int time = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player) && !pickedUp)
        {
            player.AddTime(time);
        }
        base.OnTriggerEnter(other);
    }
}
