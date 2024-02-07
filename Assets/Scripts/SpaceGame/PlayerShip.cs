using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerShip : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private GameObject destroyEffect;
	[SerializeField] private AudioSource destroySound;
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
        if(Input.GetButtonUp("Fire1") || Input.GetKeyDown(KeyCode.Tab))
        {
            inventory.OnStopUse();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out SpacePickup spacePickup))
        {

        }
        else
        {
			Death();
        }
    }

    private IEnumerator RestartTimer()
    {
        yield return new WaitForSeconds(respawnTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Death()
    {
		destroySound.Play();
		Instantiate(destroyEffect, this.transform, false);
		StartCoroutine(RestartTimer());
		rend.enabled = false;
		sf.speed = 1f;
		foreach (GameObject trail in trails)
		{
			Destroy(trail);
		}
	}
}
