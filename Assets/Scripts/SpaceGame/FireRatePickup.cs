using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRatePickup : SpacePickup
{
	protected override void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player" && other.gameObject.transform.parent.TryGetComponent(out Inventory inv))
		{
			if(inv.currentItem is Weapon)
			{
				Weapon weapon = inv.currentItem as Weapon;
				weapon.weaponData.fireRate = weapon.weaponData.fireRate * 0.5f;
			}
		}
		base.OnTriggerEnter(other);
	}
}
