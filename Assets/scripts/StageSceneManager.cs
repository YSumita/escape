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

	// Use this for initialization
	void Start () {

		if (PlayerPrefs.GetFloat ("highscore") < 500){
			hardstagelock.text = Mathf.RoundToInt(PlayerPrefs.GetFloat ("highscore")) + "/500";
		}
		else{
		hardstage.SetActive(true);
		hardstagefake.SetActive(false);
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
		SceneManager.LoadScene ("StartScene");
	}

	IEnumerator stagenormal(){
		yield return new WaitForSeconds (1f);

		SceneManager.LoadScene ("Main");
	}

	IEnumerator stagehard(){
		yield return new WaitForSeconds (1f);

		SceneManager.LoadScene ("Main");
	}

	IEnumerator stagecrazy(){
		yield return new WaitForSeconds (1f);

		SceneManager.LoadScene ("Main");
	}
}
