using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [Header("UI")]
    [SerializeField] GameObject titleUI;
    [SerializeField] GameObject endUI;
    [SerializeField] TMP_Text endScore;
    [SerializeField] TMP_Text livesUI;
    [SerializeField] TMP_Text timerUI;
    [SerializeField] Slider healthUI;

    [Header("Events")]
    [SerializeField] IntEvent scoreEvent;
    [SerializeField] VoidEvent gameStartEvent;
    [SerializeField] IntEvent gainTimeEvent;

    [SerializeField] FloatVariable health;
    [SerializeField] IntVariable score;

    [SerializeField] GameObject player;
    [SerializeField] Transform startPos;

    int finalScore;

    public enum State
    {
        TITLE,
        START_GAME,
        PLAY_GAME,
        GAME_OVER
    }

    public State state = State.TITLE;
    public float timer = 0;
    public int lives = 0;

    public int Lives {  
        get { return lives; } 
        set { lives = value; livesUI.text = "LIVES: " + lives.ToString(); } 
    }

    public float Timer {
        get {  return timer; }
        set { timer = value; timerUI.text = string.Format("{0:F1}", timer); }
    }

	private void OnEnable()
	{
        scoreEvent.Subscribe(OnAddPoints);
        gainTimeEvent.Subscribe(OnTimePickup);
		
	}

	private void OnDisable()
	{
		scoreEvent.Unsubscribe(OnAddPoints);
        gainTimeEvent.Unsubscribe(OnTimePickup);
	}

	void Start()
    {
    }

    void Update()
    {
        Debug.Log(score.value);
		switch (state)
		{
			case State.TITLE:
                titleUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
				break;
			case State.START_GAME:
				titleUI.SetActive(false);
				endUI.SetActive(false);
                player.transform.position = startPos.position;
                player.GetComponent<Rigidbody>().velocity = Vector3.zero;
                score.value = 0;
                Player p = player.GetComponent<Player>();
                p.SetPoints(0);
                health.value = 100;
                Timer = 20;
                Lives = 3;
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
                gameStartEvent.RaiseEvent();
				state = State.PLAY_GAME;
				break;
			case State.PLAY_GAME:
                Timer = Timer - Time.deltaTime;
                if(Timer <= 0 || Lives <= 0)
                {
                    state = State.GAME_OVER;
                }
                if(health.value <= 0)
                {
                    Lives = Lives - 1; 
                    player.transform.position = startPos.position;
                    health.value = 100;
                    player.GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
				break;
			case State.GAME_OVER:
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                endUI.SetActive(true);
                if(Lives <= 0 || Timer <= 0)
                {
                    endScore.text = "You Lose!";
                }
                else
                {
                    endScore.text = "Final Score: " + player.GetComponent<Player>().score;
                }
				break;
		}

        healthUI.value = health.value / 100.0f; // 100 = max health i love hard coding values
        
	}

    public void OnStartGame()
    {
        state = State.START_GAME;
    }

    public void OnRestartGame()
    {
        state = State.START_GAME;
    }

    public void OnAddPoints(int points)
    {
        //print(points);
    }

    public void OnTimePickup(int time)
    {
        Timer += time;
    }

}