using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPickup : SpacePickup
{
	protected override void OnTriggerEnter(Collider other)
	{
		Debug.Log("speed pickup");
		if (other.gameObject.TryGetComponent(out KinematicController cont))
		{
			cont.speed *= 2;
			Debug.Log("speed doubled");
		}
		base.OnTriggerEnter(other);
	}
}
