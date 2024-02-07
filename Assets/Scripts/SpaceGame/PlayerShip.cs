using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerShip : MonoBehaviour, IDamagable
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private GameObject destroyEffect;
	[SerializeField] private AudioSource destroySound;
	[SerializeField] private float respawnTime = 3;
    [SerializeField] SplineFollower sf;
    [SerializeField] MeshRenderer rend;
    [SerializeField] GameObject[] trails;

    [SerializeField] IntEvent scoreEvent;

    [SerializeField] private IntVariable score;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] FloatVariable health;


	private void Start()
	{
        scoreEvent.Subscribe(AddPoints);
        health.value = 100;
	}


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

    public void AddPoints(int points)
    {
        score.value += points;
        scoreText.text = "Score: " + score.value.ToString();
    }

	public void ApplyDamage(float damage)
	{
		health.value -= damage;

		if (health.value <= 0)
		{
            Death();
		}
	}
}
