﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverController : MonoBehaviour {

	public GameObject um;
	public GameObject dois;
	public Text HighScore;
	public Text Score;
	
	bool press;
	int select = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Vertical") > 0 && !press)
		{
			select += 1;
			press = true;
			if (select > 2)
				select = 1;
		}
		else if (Input.GetAxis("Vertical") < 0 && !press)
		{
			select -= 1;
			press = true;
			if (select < 1)
				select = 2;
		}
		else if (Input.GetAxis("Vertical").Equals(0) && press)
			press = false;
		
		if (select.Equals(1))
		{
			um.SetActive(true);
			dois.SetActive(false);
			if(Input.GetAxis("Jump") != 0 || Input.GetKeyDown(KeyCode.Return))
				Application.LoadLevel("Game");
		}
		else if (select.Equals(2))
		{
			um.SetActive(false);
			dois.SetActive(true);
			if (Input.GetAxis("Jump") != 0 || Input.GetKeyDown(KeyCode.Return))
				Application.Quit();
		}
		if (PlayerPrefs.GetFloat("score").Equals(null) || ScoreController.score > PlayerPrefs.GetFloat("score")) 
		{
			PlayerPrefs.SetFloat("score", ScoreController.score);
			HighScore.text = "HighScore  " + ScoreController.score;
			Score.text = "Score  " + ScoreController.score;
		}
		else
		{
			HighScore.text = "HighScore  " + PlayerPrefs.GetFloat("score");
			Score.text = "Score  " + ScoreController.score;

		}
		
		
	}
}
