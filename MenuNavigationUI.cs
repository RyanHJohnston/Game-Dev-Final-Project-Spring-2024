using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigationUI : MonoBehaviour
{

	GameObject[] pauseObjects;
	private static int previousSceneIndex = -1;
	private static int currentSceneIndex;

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

	// quits the game
	public void QuitGame()
	{
		Debug.Log("[INFO] Quitting Game...");
		Application.Quit();
	}

}