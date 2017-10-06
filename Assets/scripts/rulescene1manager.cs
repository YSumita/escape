using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rulescene1manager : MonoBehaviour {

	public GameObject buttonsound;
	float timer;
	int mover;
	bool push;
	// Use this for initialization
	void Start () {
		timer = -1f;
		mover = 0;
		push = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (timer >= 0) {
			timer += Time.deltaTime;
		}

		if (timer >= 0.3) {
			if (mover == 1) {
				SceneManager.LoadScene ("RuleScene2");
			}
			else if (mover == 2) {
				SceneManager.LoadScene ("StartScene");
			}
			else if (mover == 3) {
				SceneManager.LoadScene ("StartScene");
			}
			else if (mover == 4) {
				Application.Quit();
			}
		}
	}

	public void nextbutton(){
		if (push) {
			mover = 1;
			timer = 0f;
			push = false;
			Instantiate (buttonsound);
		}
	}

	public void backbutton(){
		if (push) {
			mover = 2;
			timer = 0f;
			Instantiate (buttonsound);
		}
	}

	public void homebutton(){
		if (push) {
			mover = 3;
			timer = 0f;
			Instantiate (buttonsound);
		}
	}

}