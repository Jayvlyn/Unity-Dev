using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPickup : SpacePickup
{
	[SerializeField] private float speedMod = 2f;
	private SplineFollower playerSplineFollower;
	


    protected override void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.TryGetComponent(out KinematicController cont))
		{
			cont.speed *= speedMod;
			try
			{
				playerSplineFollower = cont.gameObject.GetComponentInParent<SplineFollower>();
				if(playerSplineFollower != null)
				{
					playerSplineFollower.speed *= speedMod;
				}
			}catch{}
		}
		
		base.OnTriggerEnter(other);
	}
}
