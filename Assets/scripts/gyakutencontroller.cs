using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gyakutencontroller : MonoBehaviour {
	float timer;
	public Text gyakutenannounce;
	bool boolannounce;
	bool bool3;
	bool bool2;
	bool bool1;
	AudioSource audiosource;
	public AudioClip keihou;
	// Use this for initialization
	void Start () {
		timer = 0;
		boolannounce=true;
		bool3=true;
		bool2=true;
		bool1=true;
		audiosource = this.gameObject.GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {

		if (boolannounce) {
			if (timer >= 75) {
				gyakutenannounce.text = "Red and Green will exchange!";
				boolannounce = false;
				audiosource.PlayOneShot (keihou);
			}
		}

		if (bool3) {
			if (timer >= 77) {
				gyakutenannounce.text = "3";
				bool3 = false;
			}
		}

		if (bool2) {
			if (timer >= 78) {
				gyakutenannounce.text = "2";
				bool2 = false;
			}
		}

		if (bool1) {
			if (timer >= 79) {
				gyakutenannounce.text = "1";
				bool1 = false;
			}
		}

		if (timer >= 80) {
			GameObject[] redgrounds = GameObject.FindGameObjectsWithTag ("groundred");
			GameObject[] whitegrounds = GameObject.FindGameObjectsWithTag ("groundwhite");

			foreach (GameObject obj in redgrounds) {
				obj.GetComponent<groundcontroller> ().becomewhite = true;	
			}
			foreach (GameObject obj in whitegrounds) {
//				obj.gameObject.tag ="groundred";
//				obj.GetComponent<Renderer> ().material.color = Color.red;
//				obj.GetComponent<BoxCollider>().isTrigger = true;	
				obj.GetComponent<groundcontroller>().becomered=true;
			}
			gyakutenannounce.text = "";
			timer = 0;
			boolannounce = true;
			bool3 = true;
			bool2 = true;
			bool1 = true;
		}

		timer += Time.deltaTime;
	}
}
