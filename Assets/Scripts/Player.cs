using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] FloatVariable health;
    [SerializeField] PhysicsCharacterController characterController;
    [SerializeField] GameObject startBarrier;
    [SerializeField] AudioClip clip;

    [Header("Events")]
    [SerializeField] IntEvent scoreEvent = default;
    [SerializeField] VoidEvent gameStartEvent = default;
    [SerializeField] IntEvent timePickupEvent = default;

    public int score = 0;

    public int Score {  
        get { return score; }
        set { score = value; 
            scoreText.text = "Score: " + score.ToString();
            scoreEvent.RaiseEvent(score);
        } 
    }

	private void OnEnable()
	{
        gameStartEvent.Subscribe(OnStartGame);
	}

	private void Start()
	{
        health.value = 100f;
	}

	public void AddPoints(int points)
    {
        Score += points;
    }

    public void SetPoints(int points)
    {
        Score = points;
    }

    public void AddTime(int time)
    {
        timePickupEvent.RaiseEvent(time);
    }

    public void TakeDamage(int damage)
    {
        health.value -= damage;
        SoundManager.Instance.PlaySound(clip);
    }

    private void OnStartGame()
    {
        characterController.enabled = true;
        startBarrier.SetActive(false);
    }
}
