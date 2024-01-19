using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObstacle : MonoBehaviour
{
    [SerializeField] int damage = 10;
    private Player p;

    private void Start()
    {
        p = FindObjectOfType<Player>();   
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            p.TakeDamage(damage);
        }
    }
}
