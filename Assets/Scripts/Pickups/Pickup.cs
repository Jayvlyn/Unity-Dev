using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] protected GameObject pickupPrefab = null;
    [SerializeField] protected int points = 4000;
    [SerializeField] protected AudioClip clip;

    public MeshRenderer mesh;
    public bool pickedUp;

	private void Awake()
	{
		mesh = GetComponent<MeshRenderer>();
	}

	protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player) && !pickedUp)
        {
            player.AddPoints(points);
            SoundManager.Instance.PlaySound(clip);
            mesh.enabled = false;
            pickedUp = true;
            Instantiate(pickupPrefab, transform.position, Quaternion.identity);
        }
    }
}
