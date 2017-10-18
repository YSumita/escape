using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSceneManager : MonoBehaviour {

	public GameObject buttonsound;
	public Text hardstagelock;
	public GameObject hardstage;
	public GameObject hardstagefake;
	public Text crazystagelock;
	public GameObject crazystage;
	public GameObject crazystagefake;

	// Use this for initialization
	void Start () {

		if (PlayerPrefs.GetFloat ("highscore1") < 500){
			hardstagelock.text = Mathf.RoundToInt(PlayerPrefs.GetFloat ("highscore1")) + "/500";
		}
		else{
		hardstage.SetActive(true);
		hardstagefake.SetActive(false);
		}

		if (PlayerPrefs.GetFloat ("highscore2") < 500){
			crazystagelock.text = Mathf.RoundToInt(PlayerPrefs.GetFloat ("highscore2")) + "/500";
		}
		else{
			crazystage.SetActive(true);
			crazystagefake.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void normalstagebutton(){
		Instantiate (buttonsound);
		StartCoroutine ("stagenormal");
	}

	public void hardstagebutton(){
		Instantiate (buttonsound);
		StartCoroutine ("stagehard");
	}

	public void crazystagebutton(){
		Instantiate (buttonsound);
		StartCoroutine ("stagecrazy");
	}


	public void homebutton(){
		Instantiate (buttonsound);
		StartCoroutine ("gohome");
	}

	IEnumerator stagenormal(){
		PlayerPrefs.SetInt ("stagenum", 1);
		yield return new WaitForSeconds (1f);
		Destroy (GameObject.Find ("Audio"));
		SceneManager.LoadScene ("Main");
	}

	IEnumerator stagehard(){
		PlayerPrefs.SetInt ("stagenum", 2);
		yield return new WaitForSeconds (1f);
		Destroy (GameObject.Find ("Audio"));
		SceneManager.LoadScene ("Main");
	}

	IEnumerator stagecrazy(){
		PlayerPrefs.SetInt ("stagenum", 3);
		yield return new WaitForSeconds (1f);
		Destroy (GameObject.Find ("Audio"));
		SceneManager.LoadScene ("Main");
	}

	IEnumerator gohome(){
		yield return new WaitForSeconds (0.3f);
		SceneManager.LoadScene ("StartScene");
	}
}
