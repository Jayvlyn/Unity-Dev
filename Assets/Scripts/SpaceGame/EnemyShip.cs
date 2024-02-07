using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour, IDamagable
{
    [SerializeField] float health = 100;
    [SerializeField] private GameObject destroyEffect;
    [SerializeField] private AudioSource destroySound;

    public void ApplyDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            destroySound.Play();
            Instantiate(destroyEffect, transform, false);
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<SphereCollider>().enabled = false;
        }       
    }
}
