using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerShip : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private GameObject destroyEffect;
    [SerializeField] private float respawnTime = 3;
    [SerializeField] SplineFollower sf;
    [SerializeField] MeshRenderer rend;
    [SerializeField] GameObject[] trails;

    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            inventory.Use();
        }
        if(Input.GetButtonUp("Fire1"))
        {
            inventory.OnStopUse();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(destroyEffect, this.transform, false);
        StartCoroutine(RestartTimer());
        rend.enabled = false;
        sf.speed = 1f;
        foreach(GameObject trail in trails)
        {
            Destroy(trail);
        }
    }

    private IEnumerator RestartTimer()
    {
        yield return new WaitForSeconds(respawnTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
