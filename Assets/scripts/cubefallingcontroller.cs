using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cubefallingcontroller : MonoBehaviour {
	float timer;
	public Text cubefallingannounce;
	AudioSource audiosource;
	public AudioClip keihou;
	public AudioClip fallingsound;
	bool one;
	GameObject[] fallinggrounds;
	float ypos;
	bool fallannounce;
	bool backannounce;
	bool yadjust;

	// Use this for initialization
	void Start () {
		timer = 0;
		one = true;
		fallannounce = true;
		backannounce = true;
		yadjust = true;
		audiosource = this.gameObject.GetComponent<AudioSource> ();
		}
	// Update is called once per frame
	void Update () {

		if (fallannounce) {
			if (timer >= 25) {
				StartCoroutine ("fallingannouncecoroutine");	
				fallannounce = false;
			}
		}

		if (timer >= 30 && timer < 45) {
			if (one) {
				fallinggrounds = GameObject.FindGameObjectsWithTag ("groundred");
				foreach (GameObject obj in fallinggrounds) {
					obj.tag = "groundfall";
				}
				audiosource.PlayOneShot (fallingsound);
				one = false;
			}
			ypos=-Mathf.Pow(timer - 30,2)*3;
			foreach (GameObject obj in fallinggrounds) {
				Vector3 pos = obj.transform.position;
				pos.y = ypos;
				obj.transform.position =pos;
			}

		}

		if (timer >= 45 && timer < 60) {
			ypos=-Mathf.Pow (timer - 60,2)*3;
			foreach (GameObject obj in fallinggrounds) {
				Vector3 pos = obj.transform.position;
				pos.y = ypos;
				obj.transform.position = pos;
				//最後のy=0調整が滑らかにならないため、戻ってくるタイミングは二乗で座標を取得する方式にした
			}
		//
			if(backannounce){
				if (timer >= 55) {
				StartCoroutine ("backannouncecoroutine");
					backannounce=false;
				}
			}
		//
		}
	
		if (yadjust) {
			if (timer >= 60) {
				foreach (GameObject obj in fallinggrounds) {
					Vector3 pos = obj.transform.position;
					pos.y = 0;
					obj.transform.position = pos;
					obj.tag = "groundred";
				}
				yadjust = false;
			}
		}

		if (timer >= 80) {
			one = true;
			fallannounce = true;
			backannounce = true;
			yadjust = true;
			timer = 0;

		}

		timer += Time.deltaTime;
	}

	IEnumerator fallingannouncecoroutine(){
		cubefallingannounce.text = "Red Blocks will Fall Down!";
		audiosource.PlayOneShot (keihou);
		yield return new WaitForSeconds (2);
		cubefallingannounce.text = "3";
		yield return new WaitForSeconds (1);
		cubefallingannounce.text = "2";
		yield return new WaitForSeconds (1);
		cubefallingannounce.text = "1";
		yield return new WaitForSeconds (1);
		cubefallingannounce.text = "";
	}

	IEnumerator backannouncecoroutine(){
		cubefallingannounce.text = "Red Blocks will Come Back!";
		yield return new WaitForSeconds (2);
		cubefallingannounce.text = "3";
		yield return new WaitForSeconds (1);
		cubefallingannounce.text = "2";
		yield return new WaitForSeconds (1);
		cubefallingannounce.text = "1";
		yield return new WaitForSeconds (1);
		cubefallingannounce.text = "";
	}
}