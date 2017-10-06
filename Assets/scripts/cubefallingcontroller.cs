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
	bool fall3;
	bool fall2;
	bool fall1;
	bool backannounce;
	bool back3;
	bool back2;
	bool back1;
	bool yadjust;

	// Use this for initialization
	void Start () {
		timer = 0;
		one = true;
		fallannounce = true;
		fall3 = true;
		fall2 = true;
		fall1 = true;
		backannounce = true;
		back3 = true;
		back2 = true;
		back1 = true;
		yadjust = true;
		audiosource = this.gameObject.GetComponent<AudioSource> ();
		}
	// Update is called once per frame
	void Update () {
		if (fallannounce) {
			if (timer >= 25) {
				cubefallingannounce.text = "Red Blocks will Fall Down!";
				fallannounce = false;
				audiosource.PlayOneShot (keihou);

			} 
		}

		if (fall3) {
			if (timer >= 27) {
				cubefallingannounce.text = "3";
				fall3 = false;
			} 
		}

		if (fall2) {
			if (timer >= 28) {
				cubefallingannounce.text = "2";
				fall2 = false;
			} 
		}

		if (fall1) {
			if (timer >= 29) {
				cubefallingannounce.text = "1";
				fall1 = false;
			}
		}
	

		if (timer >= 30 && timer < 45) {
			if (one) {
				cubefallingannounce.text = "";
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
				obj.transform.position = pos;
			}

		}

		if (timer >= 45 && timer <= 60) {
			ypos=-Mathf.Pow (timer - 60,2)*3;
			foreach (GameObject obj in fallinggrounds) {
				Vector3 pos = obj.transform.position;
				pos.y = ypos;
				obj.transform.position = pos;
			}

			if(backannounce){
				if (timer >= 55) {
					cubefallingannounce.text = "Red Blocks will Come Back!";
					backannounce=false;
				}
			}

			if(back3){
				if (timer >= 57) {
					cubefallingannounce.text = "3";
					back3=false;
				}
			}

			if(back2){
				if (timer >= 58) {
					cubefallingannounce.text = "2";
					back2=false;
				}
			}

			if(back1){
				if (timer >= 59) {
					cubefallingannounce.text = "1";
				}
			}
		}

		if (yadjust) {
			if (timer >= 60) {
				foreach (GameObject obj in fallinggrounds) {
					Vector3 pos = obj.transform.position;
					pos.y = 0;
					obj.transform.position = pos;
					obj.tag = "groundred";
				}
				cubefallingannounce.text = "";
				yadjust = false;
			}
		}

		if (timer >= 80) {
			one = true;
			fallannounce = true;
			fall3 = true;
			fall2 = true;
			fall1 = true;
			backannounce = true;
			back3 = true;
			back2 = true;
			back1 = true;
			yadjust = true;
			timer = 0;

		}

		timer += Time.deltaTime;
	}
}