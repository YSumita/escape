using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using NCMB;

public class startscenemanager : MonoBehaviour {

	public GameObject buttonsound;

	public GameObject startscenebuttons;
	public GameObject nameenterbuttons;
	public InputField inputfield;
	public Text NameText;

	public GameObject BGMobj;
	Animator animator;

	// Use this for initialization
	void Start () {
		animator = nameenterbuttons.GetComponent<Animator> ();
		if (PlayerPrefs.HasKey ("playername")) {
			NameText.text = "Name: " + PlayerPrefs.GetString ("playername");
		}
		else {
			animator.SetBool ("appear", true);
		}
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void playbutton(){
			Instantiate (buttonsound);
			StartCoroutine ("play");
	}

	public void rulebutton(){
			Instantiate (buttonsound);
			StartCoroutine ("rule");
	}

	public void rankbutton(){
			Instantiate (buttonsound);
			StartCoroutine ("rank");
	}

	public void nameenterclick(){
		//名前ボックスの入力を取得。0文字かどうか判断
		if (inputfield.text.Length > 0) {
			PlayerPrefs.SetString ("playername", inputfield.text);
			Instantiate (buttonsound);
			NameText.text = "Name: " + PlayerPrefs.GetString ("playername");
			animator.SetBool ("appear", false);
			if (!PlayerPrefs.HasKey ("highscore1")) {
				PlayerPrefs.SetInt ("highscore", 0);
			}
			HighScore highScoreInstance = new HighScore (PlayerPrefs.GetInt("highscore1"), PlayerPrefs.GetString ("playername"),1);
			highScoreInstance.Save ();
		}

		else {
		}

	}

	public void namereset(){
		Instantiate (buttonsound);
		animator.SetBool ("appear", true);
	}

	IEnumerator play(){
		yield return new WaitForSeconds (0.3f);
		SceneManager.LoadScene ("StageScene");
	}
	IEnumerator rank(){
		yield return new WaitForSeconds (0.3f);
		SceneManager.LoadScene ("RankScene");
	}
	IEnumerator rule(){
		yield return new WaitForSeconds (0.3f);
		SceneManager.LoadScene ("RuleScene1");

	}
}