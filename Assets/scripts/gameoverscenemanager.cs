using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameoverscenemanager : MonoBehaviour {
	public Text lastscoretext;
	public Text highscoretext;
	int highscore;
	int lastscore;
	bool push;
	int mover;
	float timer;
	public GameObject buttonsound;
	int stagenum;
	Animator animator;
	public GameObject highscoreannounce;
	public GameObject highscoresound;

	// Use this for initialization
	void Start () {
		highscoreannounce.SetActive(false);
		animator = highscoreannounce.GetComponent<Animator> ();
		stagenum = PlayerPrefs.GetInt ("stagenum");
		mover = 0;
		timer = -1f;
		push = true;
		lastscore = PlayerPrefs.GetInt("lastscore");
		if (PlayerPrefs.HasKey ("highscore"+stagenum)) {
			highscore = PlayerPrefs.GetInt ("highscore"+stagenum);
			if (highscore < lastscore) {
				highscore = lastscore;
				PlayerPrefs.SetInt ("highscore"+stagenum, highscore);
				HighScore highScoreInstance = new HighScore (highscore, PlayerPrefs.GetString ("playername"),stagenum);
				highScoreInstance.Save ();
				highscoreannounce.SetActive (true);
				animator.SetBool ("gethighscore", true);
				Instantiate (highscoresound);


				//NCMBの自分の欄を取得して、


			}
		}
		else {
			highscore = lastscore;
			PlayerPrefs.SetInt ("highscore"+stagenum, highscore);
			HighScore highScoreInstance = new HighScore (highscore, PlayerPrefs.GetString ("playername"),stagenum);
			highScoreInstance.Save ();
			highscoreannounce.SetActive (true);
			animator.SetBool ("gethighscore", true);
			Instantiate (highscoresound);


		}
		lastscoretext.text = lastscore.ToString();
		highscoretext.text = highscore.ToString();
	}
	
	// Update is called once per frame
	void Update () {
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

	public void pushokbutton(){
		highscoreannounce.SetActive (false);
		Instantiate(buttonsound);
	}

}