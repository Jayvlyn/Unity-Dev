using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObstacle : MonoBehaviour
{
    [SerializeField] FloatVariable playerHealth;
    [SerializeField] float damage = 10.0f;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerHealth.value -= damage;
        }
    }
}
