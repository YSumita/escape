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
	float texttimer;
	Vector2 announcesize;
	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt ("stagenum") == 1) {
			Destroy (this);
		}
		timer = 0;
		boolannounce=true;
		bool3=true;
		bool2=true;
		bool1=true;
		audiosource = this.gameObject.GetComponent<AudioSource> ();
		texttimer = 0;
		announcesize = new Vector2 (1500, 500);
	}

	// Update is called once per frame
	void Update () {

		if (boolannounce) {
			if (timer >= 75) {
				StartCoroutine ("announce");
				boolannounce = false;
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

	IEnumerator announce(){
		gyakutenannounce.text = "Red and Green will exchange!";
		audiosource.PlayOneShot (keihou);

		texttimer = 0;
		while (texttimer < 2) {
			texttimer += Time.deltaTime;
			gyakutenannounce.color = new Color (255, 0, 0, 0.3f*Mathf.Sin(Mathf.PI*(texttimer*2-0.25f))+0.7f);
			yield return false;
		}

		for (int i = 3; i > 0; i--) {
			gyakutenannounce.text = i.ToString();
			texttimer = 0;
			while (texttimer < 1) {
				texttimer += Time.deltaTime;
				gyakutenannounce.rectTransform.sizeDelta = (1-texttimer) * announcesize;
				gyakutenannounce.color = new Color (255, 0, 0, 0.3f*Mathf.Sin(Mathf.PI*(texttimer*2-0.25f))+0.7f);
				yield return false;
			}
		}

		gyakutenannounce.text = "";
		gyakutenannounce.rectTransform.sizeDelta=announcesize;
	}
//		texttimer = 2;
//		while (texttimer > 0) {
//			texttimer -= Time.deltaTime;
//			gyakutenannounce.color = new Color (255, 0, 0, Mathf.FloorToInt(75*Mathf.Sin(Mathf.PI*texttimer)+175));
//			yield return false;
//		}
//
//		gyakutenannounce.color = Color.red;
//
//		for (int i = 3; i > 0; i--) {
//			gyakutenannounce.text = i.ToString();
//			texttimer = 1;
//			while (texttimer > 0) {
//				texttimer -= Time.deltaTime;
//				gyakutenannounce.rectTransform.sizeDelta = texttimer * announcesize;
//				yield return false;
//			}
//		}
//
//		gyakutenannounce.text = "";
//		gyakutenannounce.rectTransform.sizeDelta=announcesize;
//
//
//	}


}
