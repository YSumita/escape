using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundcontroller : MonoBehaviour {
	public bool becomered;
	public bool becomewhite;
	Renderer r;
	int redorgreen;
	float timer;
	float whiterate;
	// Use this for initialization
	void Start () {
		r = this.GetComponent<Renderer>();
		r.material.EnableKeyword("_EMISSION");
		redorgreen = 0;
		timer = -1f;
		becomered = false;
		becomewhite = false;
		whiterate = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (timer >= 0) {
			timer += Time.deltaTime;
			whiterate = 0.4f - 1.6f* timer*timer;
			if (redorgreen == 1) {
				r.material.SetColor ("_EmissionColor", new Color (whiterate, 0, 0));
			} 
			else if (redorgreen == 2) {
				r.material.SetColor ("_EmissionColor", new Color (0, whiterate, 0));
			}
		}

		if (becomered) {
			this.gameObject.tag = "groundred";
			r.material.color = Color.red;			
			this.GetComponent<BoxCollider>().isTrigger = true;
			r.material.SetColor ("_EmissionColor", new Color(0.4f,0,0));
			redorgreen = 1;
			timer = 0;
			becomered = false;
		}

		if (becomewhite) {
			this.gameObject.tag ="groundwhite";
			r.material.color = Color.white;
			this.GetComponent<BoxCollider>().isTrigger = false;	
			r.material.SetColor ("_EmissionColor", new Color(0,0.4f,0));
			redorgreen = 2;
			timer = 0;
			becomewhite = false;
		}


		if (timer >= 0.5f) {
			if (redorgreen == 1) {
				r.material.SetColor ("_EmissionColor", new Color (0, 0, 0));
				redorgreen = 0;
			} else if (redorgreen == 2) {
				r.material.SetColor ("_EmissionColor", new Color (0, 0, 0));
				redorgreen = 0;
			}
			timer = -1f;
		}
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "ballred") {
			becomered = true;
		} 
		if (col.gameObject.tag == "ballwhite") {
			becomewhite = true;
		}
	}


}
