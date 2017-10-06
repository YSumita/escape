using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rulescene2manager : MonoBehaviour {

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
				SceneManager.LoadScene ("RuleScene1");
			}
			else if (mover == 2) {
				SceneManager.LoadScene ("StartScene");
			}
		}
	}


	public void backbutton(){
		if (push) {
			mover = 1;
			timer = 0f;
			Instantiate (buttonsound);
			push = false;
		}
	}

	public void homebutton(){
		if (push) {
			mover = 2;
			timer = 0f;
			Instantiate (buttonsound);
			push = false;
		}
	}

}