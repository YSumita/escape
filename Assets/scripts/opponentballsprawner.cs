using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opponentballsprawner : MonoBehaviour {
	public GameObject redball;
	public GameObject purpleball;
	float ballsprawn;
	float time;
	// Use this for initialization
	void Start () {
		time = 0;
		ballsprawn = 0.005f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Random.Range (0.0f, 1.0f) < ballsprawn) {
			if (time <= 40) {
				Instantiate (redball, this.transform.position + this.transform.forward, this.transform.rotation);
			} else {
				Instantiate (purpleball, this.transform.position + this.transform.forward, this.transform.rotation);
			}
		}
		if (ballsprawn < 0.055) {
			ballsprawn += Time.deltaTime / 3000.0f;
		}
		if (ballsprawn >= 0.055 && ballsprawn < 0.075) {
			ballsprawn += Time.deltaTime / 6000.0f;
		}

		time += Time.deltaTime;
		if (time >= 50) {
			time = 0;
		}
	}
}
