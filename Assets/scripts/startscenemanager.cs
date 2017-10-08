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
	// Use this for initialization
	void Start () {

		if (GameObject.Find ("Audio(clone)") == null) {
			Instantiate (BGMobj);
		}

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