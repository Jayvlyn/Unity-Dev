using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour, IDamagable
{
    [SerializeField] float health = 100;
    [SerializeField] private int points;
    [SerializeField] private IntEvent scoreEvent;
    [SerializeField] private GameObject destroyEffect;
    [SerializeField] private AudioSource destroySound;

    [SerializeField] Weapon weapon;
    [SerializeField] private float maxFireRate;
    [SerializeField] private float minFireRate;

	private void Start()
	{
        if(weapon != null)
        {
            weapon.Equip();
            StartCoroutine(FireTimerCR());
        }
	}

	public void ApplyDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            // Points
            scoreEvent?.RaiseEvent(points);

            // destroy ship
            if(destroySound != null)destroySound.Play();
            Instantiate(destroyEffect, transform, false);
			if (TryGetComponent(out MeshRenderer renderer)) renderer.enabled = false;
			if (TryGetComponent(out SphereCollider collider)) collider.enabled = false;
        }       
    }

    IEnumerator FireTimerCR()
    {
        float time = Random.Range(minFireRate, maxFireRate);
        yield return new WaitForSeconds(time);
        weapon.Use();
    }
}
