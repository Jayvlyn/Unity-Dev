using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacePickup : MonoBehaviour
{
    [SerializeField] protected GameObject pickupPrefab = null;
    [SerializeField] protected AudioClip clip;

    public MeshRenderer mesh;
    public bool pickedUp;

	private void Awake()
	{
		mesh = GetComponent<MeshRenderer>();
	}

	protected virtual void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.TryGetComponent(out PlayerShip player) && !pickedUp)
        {
            SoundManager.Instance.PlaySound(clip);
            if(mesh != null)mesh.enabled = false;
            pickedUp = true;
            if(pickupPrefab != null)Instantiate(pickupPrefab, transform.position, Quaternion.identity);
        }
    }
}
