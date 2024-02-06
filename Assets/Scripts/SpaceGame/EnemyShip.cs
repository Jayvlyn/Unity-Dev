using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour, IDamagable
{
    [SerializeField] float health = 100;
    [SerializeField] private GameObject destroyEffect;

    public void ApplyDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Instantiate(destroyEffect, transform, false);
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<SphereCollider>().enabled = false;
        }       
    }
}
