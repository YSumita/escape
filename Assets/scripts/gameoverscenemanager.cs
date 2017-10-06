using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameoverscenemanager : MonoBehaviour {
	public Text lastscoretext;
	public Text highscoretext;
	float highscore;
	float lastscore;
	bool push;
	int mover;
	float timer;
	public GameObject buttonsound;

	// Use this for initialization
	void Start () {
		mover = 0;
		timer = -1f;
		push = true;
		lastscore = PlayerPrefs.GetFloat ("score");
		if (PlayerPrefs.HasKey ("highscore")) {
			highscore = PlayerPrefs.GetFloat ("highscore");
			if (highscore < lastscore) {
				highscore = lastscore;
				PlayerPrefs.SetFloat ("highscore", highscore);
				HighScore highScoreInstance = new HighScore (Mathf.RoundToInt(highscore), PlayerPrefs.GetString ("playername"));
				highScoreInstance.Save ();
				//NCMBの自分の欄を取得して、


			}
		}
		else {
			highscore = lastscore;
			PlayerPrefs.SetFloat ("highscore", highscore);
			Debug.Log ("aaa");
			HighScore highScoreInstance = new HighScore (Mathf.RoundToInt(highscore), PlayerPrefs.GetString ("playername"));
			highScoreInstance.Save ();

		}
		lastscoretext.text = lastscore.ToString("f0");
		highscoretext.text = highscore.ToString("f0");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("space")){
			SceneManager.LoadScene ("StartScene");
		}

		if (timer >= 0) {
			timer += Time.deltaTime;
		}

		if (timer >= 2) {
			if (mover == 1) {
				SceneManager.LoadScene ("Main");
			} 
			else if (mover == 2) {
				SceneManager.LoadScene ("StartScene");
			}

		}

	}

	public void retrybutton(){
		if (push) {
			mover = 1;
			timer = 0f;
			push = false;
			Instantiate (buttonsound);
		}
	}

	public void finishbutton(){
		if (push) {
			mover = 2;
			timer = 0f;
			push = false;
			Instantiate (buttonsound);
		}
	}

}