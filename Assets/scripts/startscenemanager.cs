using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using NCMB;

public class startscenemanager : MonoBehaviour {

	public GameObject buttonsound;
	float timer;
	int mover;
	bool push;

	public GameObject startscenebuttons;
	public GameObject nameenterbuttons;
	public InputField inputfield;
	public Text NameText;

	// Use this for initialization
	void Start () {
		timer = -1f;
		mover = 0;
		push = true;

		if (PlayerPrefs.HasKey ("playername")) {
			nameenterbuttons.SetActive(false);
			NameText.text = "Name: " + PlayerPrefs.GetString ("playername");

		}
		else {
			nameenterbuttons.SetActive(true);

		}
	}
	
	// Update is called once per frame
	void Update () {



//		if(Input.GetKeyDown("space")){
//			SceneManager.LoadScene ("Main");
//		}

		if (timer >= 0) {
			timer += Time.deltaTime;
		}

		if (timer >= 0.3) {
			if(mover==2)
			SceneManager.LoadScene ("RuleScene1");
		}

		if (timer >= 1) {
			if (mover == 1) {
				SceneManager.LoadScene ("StageScene");
			}
			else if (mover == 3) {
				SceneManager.LoadScene ("RankScene");
			}
		}
	}

	public void playbutton(){
		if (push) {
			mover = 1;
			timer = 0f;
			push = false;
			Instantiate (buttonsound);
		}
	}

	public void rulebutton(){
		if (push) {
			mover = 2;
			timer = 0f;
			Instantiate (buttonsound);
		}
	}

	public void rankbutton(){
		if (push) {
			mover = 3;
			timer = 0f;
			Instantiate (buttonsound);
		}
	}

	public void nameenterclick(){
		//名前ボックスの入力を取得。0文字かどうか判断
		if (inputfield.text.Length > 0) {
			PlayerPrefs.SetString ("playername", inputfield.text);
			startscenebuttons.SetActive(true);
			nameenterbuttons.SetActive(false);
			Instantiate (buttonsound);
			NameText.text = "Name: " + PlayerPrefs.GetString ("playername");



		}

		else {
		}

	}

	public void namereset(){
		Instantiate (buttonsound);
		nameenterbuttons.SetActive(true);
	}

}