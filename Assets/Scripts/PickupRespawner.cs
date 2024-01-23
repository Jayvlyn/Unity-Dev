using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupRespawner : MonoBehaviour
{
	[Header("Events")]
	[SerializeField] VoidEvent gameStartEvent = default;

	public List<Pickup> pickups = new List<Pickup>();

	private void Start()
	{
		foreach (Transform child in transform)
		{
			if(child.TryGetComponent(out Pickup pickup))
			{
				pickups.Add(pickup);
			}
		}
	}

	private void OnEnable()
	{
		gameStartEvent.Subscribe(OnStartGame);
	}

	private void OnStartGame()
	{
		foreach(Pickup pickup in pickups)
		{
			pickup.pickedUp = false;
			pickup.mesh.enabled = true;
		}
	}



}
