using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

	GameObject[] pauseObjects;
	GameObject[] gameOverObjects;
	[SerializeField] public PlayerUIManager playerUIManager;
	private static int previousSceneIndex = -1;
	private static int currentSceneIndex;
	[SerializeField] public PlayerState playerState;
	[SerializeField] public TMP_Text totalScoreUI;

	void Awake()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnDestroy()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	// Use this for initialization
	void Start()
	{
		Time.timeScale = 1;
		pauseObjects = GameObject.FindGameObjectsWithTag("PauseUITag");
		HidePaused();
		currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		gameOverObjects = GameObject.FindGameObjectsWithTag("GameOverUITag");
		HideGameOver();
	}

	// Update is called once per frame
	void Update()
	{

		//uses the esc button to pause and unpause the game
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (Time.timeScale == 1)
			{
				Time.timeScale = 0;
				ShowPaused();
			}
			else if (Time.timeScale == 0)
			{
				Debug.Log("high");
				Time.timeScale = 1;
				HidePaused();
			}
		}

		if (playerState.isDead)
		{
			ShowGameOver();
		}		
	}


	//Reloads the Level
	public void Reload()
	{
		SceneManager.LoadScene(Application.loadedLevel);	
	}

	//controls the pausing of the scene
	public void PauseControl()
	{
		if (Time.timeScale == 1)
		{
			Time.timeScale = 0;
			ShowPaused();
		}
		else if (Time.timeScale == 0)
		{
			Time.timeScale = 1;
			HidePaused();
		}
	}

	//shows objects with ShowOnPause tag
	public void ShowPaused()
	{
		foreach (GameObject g in pauseObjects)
		{
			g.SetActive(true);
		}
	}

	//hides objects with ShowOnPause tag
	public void HidePaused()
	{
		foreach (GameObject g in pauseObjects)
		{
			g.SetActive(false);
		}
	}

	//loads inputted level
	public void LoadLevel(string level)
	{
		SceneManager.LoadScene(level);
	}

	// load previous scene
	public void LoadPreviousLevel(string level)
	{
		if (previousSceneIndex != -1)
		{
			SceneManager.LoadScene(previousSceneIndex);
		}
		else
		{
			Debug.LogWarning("No previous cene index stored!");
		}
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		previousSceneIndex = currentSceneIndex;
		currentSceneIndex = scene.buildIndex;
	}

	// shows game over menu
	public void ShowGameOver()
	{
		foreach (GameObject g in gameOverObjects)
		{
			g.SetActive(true);
		}
		Time.timeScale = 0;
		// String totalHealth = playerUIManager.playerHealthUI.text.ToString();
		// String totalScore = playerUIManager.playerScoreUI.text.ToString();
		// String totalTime = playerUIManager.playerTimeUI.ToString();

		// totalScoreUI.text = totalScore + "\n" + totalTime;	

		// playerUIManager.playerHealthUI.text = "";
		// playerUIManager.playerScoreUI.text = "";
		// playerUIManager.playerTimeUI.text = "";

	}

	public void HideGameOver()
	{
		foreach (GameObject g in gameOverObjects)
		{
			g.SetActive(false);
		}
		Time.timeScale = 1;
			
	}

	// quits the game
	public void QuitGame()
	{
		Debug.Log("[INFO] Quitting Game...");
		Application.Quit();
	}

}
